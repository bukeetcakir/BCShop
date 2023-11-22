using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Abstract
{
	public interface ICommentService
	{
		void AddComment(Comment comment);
		//void DeleteCategory(Category category);
		//void UpdateCategory(Category category);
		List<Comment> GetList(int id);
		//Category GetById(int id);
	}
}
