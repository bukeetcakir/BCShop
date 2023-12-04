using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Abstract
{
	public interface IGenericService<T>
	{
		void AddT(T t);
		void DeleteT(T t);
		void UpdateT(T t);
		List<T> GetList();
		T GetById(int id);
	}
}
