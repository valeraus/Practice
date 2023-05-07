using System.ComponentModel.DataAnnotations;

namespace Task4.Models
{
    public class AuthorModel
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PatronymicName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<BookModel> Books { get; set; }

    }
}
