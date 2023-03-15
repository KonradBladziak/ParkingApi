using DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DatabaseContext databaseContext;
        public HomeController(DatabaseContext dbContext)
        {
            this.databaseContext = dbContext;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var miasto1 = databaseContext.Miasta.FirstOrDefault(x => x.Nazwa == "Katowice");
            Console.WriteLine(databaseContext.Parkingi.FirstOrDefault(x => x.IdMiasta == 1).Nazwa); 
            return View();
            var miasta = databaseContext.Miasta;

            Console.WriteLine(miasta.FirstOrDefault().Nazwa);
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