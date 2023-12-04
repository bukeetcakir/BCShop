using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.ViewComponents.Category
{
	public class CategoryGetList : ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EFCategoryRepository());
		public IViewComponentResult Invoke()
		{
			var categoryList = cm.GetList();
			return View(categoryList);
		}
	}
}
