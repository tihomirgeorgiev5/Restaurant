using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;

        public Menu(MenuContext context)
        {
            _context = context;
        }
        public  async Task<IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }
    }
}
