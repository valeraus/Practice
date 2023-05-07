using Task4.Models;

namespace Task4
{
    public static class DatabaseMoq
    {
        public static List<AuthorModel> Authors { get; set; }

        static DatabaseMoq()
        {
            Authors = new List<AuthorModel>()
            {
                new AuthorModel()
                {
                    Id = Guid.NewGuid(),
                    LastName = "Котляревський",
                    FirstName = "Іван",
                    PatronymicName = "Петрович",
                    DateOfBirth = new DateTime(1769,09,09),
                    Books = new List<BookModel>()
                    {
                        new BookModel(){
                            Id = Guid.NewGuid(),
                            Title = "Енеїда",
                            NumberOfPages = "350",
                            Genre =Enums.GenreType.Romantics,
                        }

                    },
                },
                new AuthorModel()
                {
                    Id = Guid.NewGuid(),
                    LastName = "Франко",
                    FirstName = "Іван",
                    PatronymicName = "Якович",
                    DateOfBirth = new DateTime(1856,08,27),
                    Books = new List<BookModel>()
                    {
                        new BookModel(){
                            Id = Guid.NewGuid(),
                            Title = "Каменярі",
                            NumberOfPages = "50",
                            Genre =Enums.GenreType.Poems,
                        },
                        new BookModel(){
                            Id = Guid.NewGuid(),
                            Title = "Захар Беркут",
                            NumberOfPages = "250",
                            Genre =Enums.GenreType.Historic,
                        },
                        new BookModel(){
                            Id = Guid.NewGuid(),
                            Title = "Мойсей",
                            NumberOfPages = "220",
                            Genre =Enums.GenreType.Historic,
                        }
                    },
                },
                new AuthorModel()
                {
                    Id = Guid.NewGuid(),
                    LastName = "Шевченко",
                    FirstName = "Тарас",
                    PatronymicName = "Григорович",
                    DateOfBirth = new DateTime(1814,09,03),
                    Books = new List<BookModel>()
                    {
                        new BookModel(){
                            Id = Guid.NewGuid(),
                            Title = "Кобзар",
                            NumberOfPages = "500",
                            Genre =Enums.GenreType.Poems,
                        }

                    },
                }
            };
        }

    }
}
