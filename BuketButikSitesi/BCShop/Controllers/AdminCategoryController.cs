using BCShop.Business.Concrete;
using BCShop.Data.Contexts;
using BCShop.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BCShop.Controllers
{
	public class AdminCategoryController : Controller
	{
		//Get AdminCategory
		public CategoryRepository categoryRepository;
		public IActionResult Index()
		{
			return View(categoryRepository.GetAll());
		}
		public IActionResult Add()
		{
			return View();
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult Add(Category c)
		{
			if (ModelState.IsValid)
			{
				categoryRepository.Update(c);
				return RedirectToAction("Index");
			}
			ModelState.AddModelError("", "Bir hata oluştu");
			return View();
		}
	}
}
