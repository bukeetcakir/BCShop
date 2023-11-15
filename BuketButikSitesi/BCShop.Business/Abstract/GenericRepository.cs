using BCShop.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Abstract
{
	public class GenericRepository<T> : IRepository<T> where T : class, new()
	{
		protected readonly Context _dbContext;
		public GenericRepository(Context dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(T entity)
		{
			_dbContext.Set<T>().Add(entity);
			_dbContext.SaveChanges();
		}

		public void Delete(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			_dbContext.SaveChanges();
		}

		public List<T> GetAll()
		{
			return _dbContext.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _dbContext.Set<T>().Find(id);
		}

		public void Update(T entity)
		{
			_dbContext.Entry<T>(entity).State = EntityState.Modified;
			_dbContext.SaveChanges();

		}
	}
}
