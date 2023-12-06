using BCShop.Data.Abstract;
using BCShop.Data.Concrete;
using BCShop.Data.Repositories;
using BCShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BCShop.Data.EntityFramework
{
	public class EFCartRepository : GenericRepository<Cart>, ICartDAL
	{
		public void ClearCart(int cartId)
		{
            using (var context = new Context())
            {
                var cmd = @"delete from CartItem where CartID=@p0";
                context.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }

		public void DeleteFromCart(int cartId, int productId)
		{
            using (var context = new Context())
            {
                var cmd = @"delete from CartItem where CartID=@p0 And ProductID=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

		public Cart GetByUserId(int userId)
		{
			using (var context = new Context())
			{
				return context
							.Carts
							.Include(i => i.CartItems)
							.ThenInclude(i => i.Product)
							.FirstOrDefault(i => i.UserID == userId);
			}
		}
	}
}
