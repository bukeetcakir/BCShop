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
using Microsoft.AspNetCore.Authorization;

namespace BCShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class ProductController : Controller
	{
		ProductManager pm = new ProductManager(new EFProductRepository());
		const string _imageFullPath = @"C:\Users\Buket\Documents\GitHub\BuketButikSitesi\BuketButikSitesi-\BCShop\BCShop\wwwroot\BCShopTheme\images\";
			const string _imageDbPath = @"/BCShopTheme/images/";
		public IActionResult Index()
		{
			var values = pm.GetProductListWithCategory();
			return View(values);
		}
		[HttpGet]
		public IActionResult Create()
		{
			var cm = new CategoryManager(new EFCategoryRepository());
			List<SelectListItem> categories = (from c in cm.GetList()
											   select new SelectListItem
											   {
												   Text = c.Name,
												   Value = c.CategoryID.ToString()
											   }).ToList();
			ViewBag.cv = categories;
			return View();
		}

		public bool SaveFile(IFormFile file, string fullPath)
		{
			try
			{
				byte[] fileByte;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					file.CopyTo(memoryStream);
					fileByte = memoryStream.ToArray();
				}
				using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
				{
					fileStream.Write(fileByte, 0, fileByte.Length);
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}


		[HttpPost]
		public IActionResult Create(Product p, IFormFile image)
		{
			ProductValidator pv = new ProductValidator();
			ValidationResult results = pv.Validate(p);
			string imagePath = _imageFullPath + image.FileName;
			string dbImagePath = _imageDbPath + image.FileName;
			if (results.IsValid)
			{
				p.Status = true;
				if (SaveFile(image, imagePath))
				{
					p.ImageUrl = dbImagePath;
				}
				else
				{
					ModelState.AddModelError("image", "Ürün görseli boþ geçilemez");
					return View();
				}
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
            var cm = new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> categories = (from c in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = c.Name,
                                                   Value = c.CategoryID.ToString()
                                               }).ToList();
            ViewBag.cv = categories;
            var value = pm.GetById(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult Edit(Product p, IFormFile image)
		{
			ProductValidator pv = new ProductValidator();
			ValidationResult results = pv.Validate(p);
			string imagePath = _imageFullPath + image.FileName;
			string dbImagePath = _imageDbPath + image.FileName;
			if (results.IsValid)
			{
				if (SaveFile(image, imagePath))
				{
					p.ImageUrl = dbImagePath;
				}
				else
				{
					ModelState.AddModelError("image", "Ürün görseli boþ geçilemez");
					return View();
				}

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