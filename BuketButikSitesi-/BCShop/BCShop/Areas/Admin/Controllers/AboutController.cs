using BCShop.Business.Concrete;
using BCShop.Business.ValidationRules;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Policy = "AdminPolicy")]
	public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutRepository());
        public IActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(About a)
        {
            AboutValidator abv = new AboutValidator();
            ValidationResult results = abv.Validate(a);
            if (results.IsValid)
            {
                a.Status = true;
                abm.AddT(a);
                return RedirectToAction("Index", "About");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var value = abm.GetById(id);
            abm.DeleteT(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = abm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(About a)
        {
            AboutValidator abv = new AboutValidator();
            ValidationResult results = abv.Validate(a);
            if (results.IsValid)
            {
                a.Status = true;
                abm.UpdateT(a);
                return RedirectToAction("Index", "About");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
