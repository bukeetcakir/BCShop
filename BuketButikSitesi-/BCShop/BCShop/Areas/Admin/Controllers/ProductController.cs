using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BCShop.Data;
using BCShop.Business.Concrete;
using BCShop.Business.ValidationRules;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BCShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EFProductRepository());
        public IActionResult Index()
        {
            var values = pm.GetProductListWithCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var cm =new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> categories = (from c in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text=c.Name,
                                                   Value=c.CategoryID.ToString()
                                               }).ToList();
            ViewBag.cv = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            ProductValidator pv = new ProductValidator();
            ValidationResult results = pv.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                //p.CategoryID = 1;
                pm.AddT(p);
                return RedirectToAction("Index", "Product");
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
            var value = pm.GetById(id);
            pm.DeleteT(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = pm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            ProductValidator pv = new ProductValidator();
            ValidationResult results = pv.Validate(p);
            if (results.IsValid)
            {
                pm.UpdateT(p);
                return RedirectToAction("Index", "Product");
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