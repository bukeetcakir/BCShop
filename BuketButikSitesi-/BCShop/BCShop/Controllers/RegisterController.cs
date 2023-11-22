using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	public class RegisterController : Controller
	{
		UserManager um = new UserManager(new EFUserRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(User u)
		{
			u.Status = "true";
			um.UserAdd(u);
			return RedirectToAction("Index", "Product");
		}
	}
}
