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
	public class EFProductRepository : GenericRepository<Product>, IProductDAL
	{
		public List<Product> GetProductsWithCategory()
		{
			using (var c = new Context())
			{
				return c.Products.Include(x => x.Category).ToList();
			}
		}
	}
}
