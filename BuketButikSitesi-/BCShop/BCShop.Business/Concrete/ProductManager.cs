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

		
		public Product GetById(int id)
		{
            return _productDAL.GetById(id);
        }
        public List<Product> GetProductById(int id)
		{
			return _productDAL.GetAll(x => x.ProductID == id);
		}
		public List<Product> GetProductByCategoryId(int id)
		{

			return _productDAL.GetAll(x => x.CategoryID == id);
		}
		public List<Product> GetList()
		{
			return _productDAL.GetAll();
		}

		public List<Product> GetProductListWithCategory()
		{
			return _productDAL.GetProductsWithCategory();
		}


        public void AddT(Product t)
        {
            _productDAL.Insert(t);
        }

        public void DeleteT(Product t)
        {
            _productDAL.Delete(t);

        }

        public void UpdateT(Product t)
        {
            _productDAL.Update(t);
        }
    }
}
