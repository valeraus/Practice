using Task4.Enums;

namespace Task4.Models
{
    public class JoinModel
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PatronymicName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string NumberOfPages { get; set; }
        public GenreType Genre { get; set; }
        public Guid AuthorId { get; set; }

    }
}
