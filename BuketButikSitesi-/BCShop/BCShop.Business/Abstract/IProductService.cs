using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Abstract
{
	public interface IProductService
	{
		void AddProduct(Product product);
		void DeleteProduct(Product product);
		void UpdateProduct(Product product);
		List<Product> GetList();
		Product GetById(int id);
		List<Product> GetProductListWithCategory();
	}
}
