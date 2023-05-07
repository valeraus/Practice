using Task4.Enums;

namespace Task4.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string NumberOfPages { get; set; }
        public GenreType Genre { get; set; }


    }
}
