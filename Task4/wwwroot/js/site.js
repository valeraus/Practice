var app = new Vue({
    el: "#app",

    data: {

        url: "/api/",
        authors: [],
        showEditAuthorModal: false,
        changeAuthor: null,
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

        ShowAuthors() {
        },
        ShowGenres() {

        },
        ViewAuthor(index) {
        },
        saveBook() {
            // Save the book data to the database
            // ...
            // Hide the modal window
            this.$emit('close');
        },
        cancel() {
            // Hide the modal window without saving changes
            this.$emit('close');
        },

        ToDate(str) {
            let allDate = new Date(str).toDateString();
            let fDate = allDate.split(" ");
            return fDate[2] + " " + fDate[1] + " " + fDate[3];
        }
    }
})