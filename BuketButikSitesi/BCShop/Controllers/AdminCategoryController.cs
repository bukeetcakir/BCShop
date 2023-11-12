using BCShop.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
    public class AdminCategoryController : Controller
    {
		//Get AdminCategory
		public CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }
    }
}
