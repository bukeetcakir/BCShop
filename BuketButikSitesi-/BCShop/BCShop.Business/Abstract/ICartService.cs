using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Abstract
{
	internal interface ICartService : IGenericService<Cart>
	{
		void InitializeCart(int userId);
		Cart GetCartByUserId(int userId);
		void AddToCart(int userId, int productId, int quantity);
		void DeleteFromCart(int userId, int productId);
		void ClearCart(int cartId);
	}
}
