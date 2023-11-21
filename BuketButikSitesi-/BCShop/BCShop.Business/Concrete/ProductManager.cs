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
	public class ProductManager : IProductService
	{
		IProductDAL _productDAL;

		public ProductManager(IProductDAL productDAL)
		{
			_productDAL = productDAL;
		}

		public void AddProduct(Product product)
		{
			throw new NotImplementedException();
		}

		public void DeleteProduct(Product product)
		{
			throw new NotImplementedException();
		}

		public Product GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetList()
		{
			return _productDAL.GetAll();
		}

		public List<Product> GetProductListWithCategory()
		{
			return _productDAL.GetProductsWithCategory();
		}

		public void UpdateProduct(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
