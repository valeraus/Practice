class Author {
    constructor() {
        this.id = "";
        this.lastName = "";
        this.firstName = "";
        this.patronymicName = "";
        this.dateOfBirth = new Date();
        this.books = [];
    }
}

var app = new Vue({
    el: "#app",
    data: {
        url: "/api/",
        authors: [],
        genres: [],
        showEditAuthorModal: false,
        changeAuthor: null,
    },

    watch: {
        authors() {
            this.genres = [
                { name: "Романтика", books: [], authors: [] },
                { name: "Детективи", books: [], authors: [] },
                { name: "Поеми", books: [], authors: [] },
                { name: "Фантастика", books: [], authors: [] },
                { name: "Історичні", books: [], authors: [] },
            ]

            this.authors.forEach(a => {
                a.books.forEach(b => {
                    if (b.genre == 1) {
                        this.genres[0].books.push(b);
                        this.genres[0].authors.push(a);
                    }
                    if (b.genre == 2) {
                        this.genres[1].books.push(b);
                        this.genres[1].authors.push(a);
                    }
                    if (b.genre == 3) {
                        this.genres[2].books.push(b);
                        this.genres[2].authors.push(a);
                    }
                    if (b.genre == 4) {
                        this.genres[3].books.push(b);
                        this.genres[3].authors.push(a);
                    }
                    if (b.genre == 5) {
                        this.genres[4].books.push(b);
                        this.genres[4].authors.push(a);
                    }
                });
            })
        },
    },

    created() {
        this.Load();
    },
    methods: {
        Load() {
            axios.get(this.url + "AuthorLoad").then((response) => {
                this.authors = response.data;
            });
        },
        ChoseAuthor(index) {
            this.changeAuthor = JSON.parse(JSON.stringify(this.authors[index]));
            this.showEditAuthorModal = true;
        },
        DeleteAuthor() {
            var params = new URLSearchParams();
            params.append("id", this.changeAuthor.id);
            axios.get(this.url + "DeleteAuthor", { params }).then((response) => {
                this.authors = response.data;
            });
        },
        SaveAuthor() {
            var params = this.changeAuthor;
            axios.get(this.url + "SaveAuthor", { params }).then((response) => {
                this.authors = response.data;
            });
        },
        InitAuthor() {
            this.changeAuthor = new Author();
        },
        CreateAuthor() {
            var params = this.changeAuthor;
            axios.get(this.url + "CreateAuthor", { params }).then((response) => {
                this.authors = response.data;
            });
        },
        Save() {
            if (this.changeAuthor.id == 0) {
                this.CreateAuthor();
            }
            else {
                this.SaveAuthor();
            }
        },
        AddBook() {
            const newBook = {
                title: '',
                pages: 0,
                genre: 0
            };
            this.changeAuthor.books.push(newBook);
        },
        BookSave() {
            var params = new URLSearchParams();
            params.append("authorJson", JSON.stringify(this.changeAuthor));
            axios.get(this.url + "AddBook", { params })
                .then((response) => {
                    this.authors = response.data;
                });
        },
        BookDel(book) {
            var params = new URLSearchParams();
            params.append("bookId", book.id);
            axios.get(this.url + "DeleteBook", { params })
                .then((response) => {
                    this.authors = response.data;
                    this.changeAuthor.books = this.changeAuthor.books.filter(b => b.id != book.id);
                });
        },

        ShowAuthors() {
            this.showAuthors = true;
        },
        ShowGenres() {
            this.showAuthors = false;
        },

        ShowGenre() {
            axios.get(this.url).then(response => {
                document.documentElement.innerHTML = response.data;
            });
        },

        getAuthorNames(book) {
            const authorNames = [];
            this.authors.forEach(author => {
                if (author.books.includes(book)) {
                    authorNames.push(author.lastName + ' ' + author.firstName);
                }
            });
            return authorNames.join(', ');
        },




        ToDate(str) {
            let allDate = new Date(str).toDateString();
            let fDate = allDate.split(" ");
            return fDate[2] + " " + fDate[1] + " " + fDate[3];
        }
    }
})