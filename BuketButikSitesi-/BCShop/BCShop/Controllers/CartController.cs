using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using BCShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace BCShop.Controllers
{
	[AllowAnonymous]
	public class CartController : Controller
	{
		CartManager cm = new CartManager(new EFCartRepository());

		public IActionResult Index()
		{
			var cart = cm.GetCartByUserId(1);
			return View(new CartModel()
			{
				CartId = cart.CartID,
				CartItems = cart.CartItems.Select(i => new CartItemModel()
				{
					CartItemId = i.Id,
					ProductId = i.ProductID,
					Name = i.Product.Name,
					Price = i.Product.Price,
					ImageUrl = i.Product.ImageUrl,
					Quantity = i.Quantity
				}).ToList()
			});
		}
		[HttpPost]
		public IActionResult AddToCart(int productId, int quantity)
		{
			cm.AddToCart(1, productId, quantity);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult DeleteFromCart(int productId)
		{
			cm.DeleteFromCart(1, productId);
			return RedirectToAction("Index");
		}
		public IActionResult Checkout()
		{
			var cart = cm.GetCartByUserId(1);

			var orderModel = new OrderModel();

			orderModel.CartModel = new CartModel()
			{
				CartId = cart.CartID,
				CartItems = cart.CartItems.Select(i => new CartItemModel()
				{
					CartItemId = i.Id,
					ProductId = i.ProductID,
					Name = i.Product.Name,
					Price = i.Product.Price,
					ImageUrl = i.Product.ImageUrl,
					Quantity = i.Quantity
				}).ToList()
			};

			return View(orderModel);
		}
		[HttpPost]
		public IActionResult Checkout(OrderModel model)
		{
			if (ModelState.IsValid)
			{
				var userId = 1;
				var cart = cm.GetCartByUserId(userId);

				model.CartModel = new CartModel()
				{
					CartId = cart.CartID,
					CartItems = cart.CartItems.Select(i => new CartItemModel()
					{
						CartItemId = i.Id,
						ProductId = i.ProductID,
						Name = i.Product.Name,
						Price = i.Product.Price,
						ImageUrl = i.Product.ImageUrl,
						Quantity = i.Quantity
					}).ToList()
				};
			}

			return View(model);
		}

        

        private void ClearCart(int cartId)
		{
			cm.ClearCart(cartId);
		}

	}
}

		

