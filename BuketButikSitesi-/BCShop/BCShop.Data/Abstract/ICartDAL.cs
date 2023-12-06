using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Data.Abstract
{
	public interface ICartDAL : IGenericDAL<Cart>
	{
		Cart GetByUserId(int userId);
		void DeleteFromCart(int cartId, int productId);
		void ClearCart(int cartId);
	}
}
