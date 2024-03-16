using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models;

namespace MVC.Controllers
{
    //[MyLog]
    public class HelloController : Controller
    {
        private readonly MyContext _context;

        public HelloController(MyContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return Content("Hello, World!");
        }

        [MyLog]
        public IActionResult Greet()
        {
            //ViewData["Message"] = "こんにちは、世界！";
            ViewBag.Message = "こんにちは、世界！";
            //return View("Greet");
            return View();
        }

        public IActionResult List()
        {
            return View(this._context.Books);
        }

        [Route("hoge/foo")]
        public IActionResult Foo()
        {
            return View("List", this._context.Books);
        }
    }
}
