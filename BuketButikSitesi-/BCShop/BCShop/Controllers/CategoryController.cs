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

		public IActionResult Details(int id)
		{
			ViewBag.Id = id;
			var pm = new ProductManager(new EFProductRepository());
			var pWithC = pm.GetProductByCategoryId(id);

			return View(pWithC);
		}
	}
}
