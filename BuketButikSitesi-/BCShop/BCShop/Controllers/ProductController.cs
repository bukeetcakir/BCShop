using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	public class ProductController : Controller
	{
		ProductManager pm = new ProductManager(new EFProductRepository());
		public IActionResult Index()
		{
			var products = pm.GetProductListWithCategory();
			return View(products);
		}
	}
}
