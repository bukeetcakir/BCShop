using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	public class ContactController : Controller
	{
		ContactManager cm = new ContactManager(new EFContactRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact c)
		{
			c.Status = true;
			c.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
			cm.ContactAdd(c);
			return RedirectToAction("Index","Product");
		}
	}
}
