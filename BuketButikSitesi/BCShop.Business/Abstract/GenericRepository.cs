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
        protected readonly Context _db;
        public GenericRepository(Context dbcontext)
        {
            _db = dbcontext;
        }
        DbSet<T> _data;

        public void Add(T entity)
        {
            _data.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _data.ToList();
        }

        public T GetById(int id)
        {
            return _data.Find(id);
        }

        public void Update(T entity)
        {
            _db.Entry<T>(entity).State = EntityState.Modified;
            _db.SaveChanges();

        }
    }
}
