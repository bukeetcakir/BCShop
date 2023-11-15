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

		public AdminCategoryController(CategoryRepository category)
		{
			categoryRepository = category;
		}

		public ActionResult Index()
		{
			return View(categoryRepository.GetAll());
		}
		public ActionResult Add()
		{
			return View();
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Add(Category c)
		{
			if (ModelState.IsValid)
			{
				categoryRepository.Update(c);
				return RedirectToAction("Index");
			}
			ModelState.AddModelError("", "Bir hata oluştu");
			return View();
		}

		public ActionResult Delete(int id)
		{
			var delete = categoryRepository.GetById(id);
			categoryRepository.Delete(delete);
			return RedirectToAction("Index");
		}
		public ActionResult Update(int id)
		{
			var update = categoryRepository.GetById(id);
			return View(update);
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Update(Category c)
		{
			if (ModelState.IsValid)
			{
				var update = categoryRepository.GetById(c.Id);
				update.Name = c.Name;
				update.Description = c.Description;
				categoryRepository.Update(update);
				return RedirectToAction("Index");
			}
			ModelState.AddModelError("", "Bir Hata oluştu");
			return View();

		}
	}
}
