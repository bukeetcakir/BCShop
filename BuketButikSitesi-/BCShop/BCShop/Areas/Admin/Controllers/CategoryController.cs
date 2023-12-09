using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BCShop.Business.Concrete;
using BCShop.Business.ValidationRules;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BCShop.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Policy = "AdminPolicy")]
	public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(c);
            if (results.IsValid)
            {
                c.Status = true;
                cm.AddT(c);
                return RedirectToAction("Index", "Category");
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
            var value = cm.GetById(id);
            cm.DeleteT(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = cm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(c);
            if (results.IsValid)
            {
                cm.UpdateT(c);
                return RedirectToAction("Index", "Category");
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