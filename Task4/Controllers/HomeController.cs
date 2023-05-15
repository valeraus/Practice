using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Task4.Models;

namespace Task4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        IDbConnection Connect 
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Local"));
            }
        }

        public async Task<IActionResult> Index()
        {
            List<AuthorModel> list = new List<AuthorModel>();

            using (IDbConnection database = Connect)
            {
                var query = await database.QueryAsync<AuthorModel>("SELECT * FROM Authors");
                list = query.ToList();
            }
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}