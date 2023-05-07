using Microsoft.AspNetCore.Mvc;
using Task4.Models;

namespace Task4.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult AuthorLoad()
        {
            return Json(DatabaseMoq.Authors);
        }
        public IActionResult DeleteAuthor(Guid id)
        {
            DatabaseMoq.Authors.RemoveAll(a => a.Id == id);
            return Json(DatabaseMoq.Authors);
        }
        public IActionResult SaveAuthor(AuthorModel newAuthor)
        {
            var author = DatabaseMoq.Authors.FirstOrDefault(a => a.Id == newAuthor.Id);
            if (author != null) { 
                author.LastName = newAuthor.LastName;
                author.FirstName = newAuthor.FirstName;
                author.PatronymicName = newAuthor.PatronymicName;
                //author.Books.Title = newAuthor.Books.Title;
                //author.Books.NumberOfPages = newAuthor.Books.NumberOfPages;
            }
            return Json(DatabaseMoq.Authors);
        }
    }
}
