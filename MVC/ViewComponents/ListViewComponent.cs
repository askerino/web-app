using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.ViewComponents
{
    public class ListViewComponent : ViewComponent
    {
        private readonly MyContext _context;

        public ListViewComponent(MyContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int price)
        {
            return View(await _context.Books!.Where(b => b.Price > price).ToListAsync());
        }
    }
}
