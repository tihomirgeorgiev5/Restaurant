using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class Menu : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
