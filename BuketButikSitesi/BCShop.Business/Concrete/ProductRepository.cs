using BCShop.Business.Abstract;
using BCShop.Data.Contexts;
using BCShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Concrete
{
	public class ProductRepository : IGenericRepository<Product>
	{
		public ProductRepository(Context dbContext) : base(dbContext)
		{

		}

	}
}
