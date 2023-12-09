using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using BCShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.ViewComponents.Cart
{
    public class CartItemCount : ViewComponent
    {
        CartManager cm = new CartManager(new EFCartRepository());

        [HttpGet]
        public IViewComponentResult Invoke()
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
    }
}
