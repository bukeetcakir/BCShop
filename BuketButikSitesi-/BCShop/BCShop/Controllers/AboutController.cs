using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EFAboutRepository());
		public IActionResult Index()
		{
			var values = abm.GetList();
			return View(values);
		}

	}
}
