using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
