using BCShop.Business.Abstract;
using BCShop.Data.Abstract;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDAL _categoryDAL;
		public CategoryManager(ICategoryDAL categoryDAL)
		{
			_categoryDAL = categoryDAL;
		}

		public void AddCategory(Category category)
		{
			_categoryDAL.Insert(category);
		}

		public void DeleteCategory(Category category)
		{
			_categoryDAL.Delete(category);
		}

		public Category GetById(int id)
		{
			return _categoryDAL.GetById(id);
		}

		public List<Category> GetList()
		{
			return _categoryDAL.GetAll();
		}

		public void UpdateCategory(Category category)
		{
			_categoryDAL.Update(category);
		}
	}
}
