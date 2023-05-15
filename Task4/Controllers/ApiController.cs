using Dapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using Task4.Models;

namespace Task4.Controllers
{
    public class ApiController : Controller
    {

        private readonly IConfiguration _config;

        public ApiController(IConfiguration config)
        {
            _config = config;
        }

        IDbConnection Connect
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Local"));
            }
        }

        public async Task<IActionResult> AuthorLoad()
        {
            using (IDbConnection database = Connect)
            {
                var authors = await Select(database);
                return Json(authors);
            }
        }

        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            using (IDbConnection database = Connect)
            {
                await database.ExecuteAsync("DELETE FROM Authors WHERE Id = @Id", new { Id = id });

                var authors = await Select(database);
                return Json(authors);
            }
        }
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            using (IDbConnection database = Connect)
            {
                await database.ExecuteAsync("DELETE FROM Books WHERE Id = @Id", new { Id = bookId });

                var authors = await Select(database);
                return Json(authors);
            }
        }
        public async Task<IActionResult> CreateAuthor(AuthorModel newAuthor)
        {
            newAuthor.Id = Guid.NewGuid();
            using (IDbConnection database = Connect)
            {
                await database.ExecuteAsync("INSERT INTO Authors VALUES (@Id, @LastName, @FirstName, @PatronymicName, @DateOfBirth)", newAuthor);

                var authors = await Select(database);
                return Json(authors);
            }
        }
        public async Task<IActionResult> AddBook(string authorJson)
        {
            var newAuthor = JsonConvert.DeserializeObject<AuthorModel>(authorJson);
            using (IDbConnection database = Connect)
            {
                if (newAuthor != null)
                {
                    var authors = await Select(database);
                    var author = authors.FirstOrDefault(a => a.Id == newAuthor.Id);

                    foreach (BookModel book in newAuthor.Books)
                    {
                        var find = author?.Books.FirstOrDefault(b => b.Id == book.Id);
                        if (find != null)
                        {
                            await database.ExecuteAsync("UPDATE Books " +
                                "SET Title = @Title, " +
                                "NumberOfPages = @NumberOfPages, " +
                                "Genre = @Genre " +
                                "WHERE Id = @Id", book);
                        }
                        else
                        {
                            await database.ExecuteAsync("INSERT INTO Books " +
                                "VALUES " +
                                "(@Id,@Title,@NumberOfPages,@Genre,@AuthorId)", new BookModel()
                                {
                                    Id = Guid.NewGuid(),
                                    Title = book.Title,
                                    NumberOfPages = book.NumberOfPages,
                                    Genre = book.Genre,
                                    AuthorId = author.Id,
                                });
                        }
                    }
                }

                return Json(await Select(database));
            }
        }
        public async Task<IActionResult> SaveAuthor(AuthorModel newAuthor)
        {
            using (IDbConnection database = Connect)
            {
                await database.ExecuteAsync("UPDATE Authors " +
                            "SET LastName = @LastName, " +
                            "FirstName = @FirstName, " +
                            "PatronymicName = @PatronymicName " +
                            "WHERE Id = @Id", newAuthor);

                return Json(await Select(database));
            }
        }

        async Task<List<AuthorModel>> Select(IDbConnection database)
        {
            var authors = await database.QueryAsync<AuthorModel>("SELECT * FROM Authors");
            var books = await database.QueryAsync<BookModel>("SELECT * FROM Books");

            var join = from author in authors
                       from book in books
                       group book by book.AuthorId into booksGroup
                       join author in authors
                       on booksGroup.Key equals author.Id
                       select new AuthorModel()
                       {
                           Id = author.Id,
                           FirstName = author.FirstName,
                           DateOfBirth = author.DateOfBirth,
                           LastName = author.LastName,
                           PatronymicName = author.PatronymicName,
                           Books = booksGroup.ToList()
                       };


            var result = join.ToList();

            foreach (var author in result)
            {
                var find = authors.FirstOrDefault(a => a.Id == author.Id);
                if (find != null)
                {
                    find.Books = author.Books.Distinct().ToList();
                }
            }

            return authors.ToList();
        }
    }
}
