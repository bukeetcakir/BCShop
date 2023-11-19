using BCShop.Business.Concrete;
using BCShop.Data.Contexts;
using BCShop.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BCShop.Controllers
{
	public class AdminProductController : Controller
	{
		private ProductRepository productRepository;
		private CategoryRepository categoryRepository;
		Context dbContext;

		public AdminProductController(ProductRepository productRepository, CategoryRepository categoryRepository)
		{
			this.productRepository = productRepository;
			this.categoryRepository = categoryRepository;
		}

		public ActionResult Index()
		{
			return View(productRepository.GetAll());
		}


		public ActionResult Add(Product p)
		{
			List<SelectListItem> category = (from c in categoryRepository.GetAll()
											 select new SelectListItem
											 {
												 Text = c.Name,
												 Value = c.Id.ToString()
											 }).ToList();
			ViewBag.Category = category;
			return View();
		}

		[HttpPost]
		public ActionResult Add(Product p, IFormFile File)
		{
			if (ModelState.IsValid)
			{
				string path = Path.Combine("~/Images/" + File.FileName);
				Directory.CreateDirectory(path);
				p.Image = File.FileName.ToString();
				productRepository.Add(p);
				return RedirectToAction("Index");
			}
			ModelState.AddModelError("", "Bir hata oluştu");
			return View();
		}
	}
}
