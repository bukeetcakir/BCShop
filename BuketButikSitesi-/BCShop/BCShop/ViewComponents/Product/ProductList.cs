using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.ViewComponents.Product
{
	public class ProductList:ViewComponent
	{
		ProductManager pm = new ProductManager(new EFProductRepository());
		public IViewComponentResult Invoke()
		{
			var products = pm.GetProductListWithCategory();
			return View(products);
		}
	}
}
