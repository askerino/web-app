using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MyContext context, ILogger<HomeController> logger)
        {
            Random r = new Random();
            _context = context;
            _logger = logger;
            Book book = new Book();
            book.Id = r.Next(1000);
            book.Title = "Title";
            book.Price = 1000;
            book.Publisher = "Pub";
            book.Sample = true;
            _context.Add(book);
            _context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
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