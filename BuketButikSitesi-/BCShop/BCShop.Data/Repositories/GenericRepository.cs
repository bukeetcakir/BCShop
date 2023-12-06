using BCShop.Data.Abstract;
using BCShop.Data.Concrete;
using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Data.Repositories
{
	public class GenericRepository<T> : IGenericDAL<T> where T : class
	{
		Context c = new Context();

		public void Delete(T entity)
		{
			c.Remove(entity);
			c.SaveChanges();
		}

		public List<T> GetAll()
		{
			return c.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return c.Set<T>().Find(id);
		}

		public void Insert(T entity)
		{
			c.Add(entity);
			c.SaveChanges();
		}

		public List<T> GetAll(Expression<Func<T, bool>> expression)
		{
			return c.Set<T>().Where(expression).ToList();
		}

		public void Update(T entity)
		{

			c.Update(entity);
			c.SaveChanges();
		}
	}
}
