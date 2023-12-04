using BCShop.Business.Concrete;
using BCShop.Business.ValidationRules;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	public class RegisterController : Controller
	{
		UserManager um = new UserManager(new EFUserRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(User u)
		{
			UserValidator uv = new UserValidator();
			ValidationResult result = uv.Validate(u);
			if (result.IsValid)
			{
				u.Status = "true";
				um.UserAdd(u);
				return RedirectToAction("Index", "Product");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
