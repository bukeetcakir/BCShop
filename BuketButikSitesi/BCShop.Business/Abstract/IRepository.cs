using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
    }
}
