using BCShop.Business.Abstract;
using BCShop.Data.Abstract;
using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Concrete
{
	public class CartManager
	{
		private ICartDAL _cartDal;
		public CartManager(ICartDAL cartDal)
		{
			_cartDal = cartDal;
		}

		public void AddToCart(int userId, int productId, int quantity)
		{
			var cart = GetCartByUserId(userId);
			if (cart != null)
			{
				var index = cart.CartItems.FindIndex(i => i.ProductID == productId);

				if (index < 0)
				{
					cart.CartItems.Add(new CartItem()
					{
						ProductID = productId,
						Quantity = quantity,
						CartID = cart.CartID
					});
				}
				else
				{
					cart.CartItems[index].Quantity += quantity;
				}

				_cartDal.Update(cart);
			}
		}

		public void ClearCart(int cartId)
		{
			_cartDal.ClearCart(cartId);
		}

		public void DeleteFromCart(int userId, int productId)
		{
			var cart = GetCartByUserId(userId);
			if (cart != null)
			{
				_cartDal.DeleteFromCart(cart.CartID, productId);
			}
		}

		public Cart GetCartByUserId(int userId)
		{
			return _cartDal.GetByUserId(userId);
		}

		public void InitializeCart(int userId)
		{
			_cartDal.Insert(new Cart() { UserID = userId });
		}
	}
}
