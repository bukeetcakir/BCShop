using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	[AllowAnonymous]
	public class ProductController : Controller
	{
		ProductManager pm = new ProductManager(new EFProductRepository());
		public IActionResult Index()
		{
			var products = pm.GetProductListWithCategory();
			return View(products);
		}
		public IActionResult Details(int id)
		{
			ViewBag.Id = id;
			var products = pm.GetProductsById(id);
			return View(products);
		}
	}
}
