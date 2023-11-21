using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	public class CategoryController : Controller
	{
		CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
		public IActionResult Index()
		{
			var categories = categoryManager.GetList();
			return View(categories);
		}
	}
}
