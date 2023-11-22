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
	public class CommentManager : ICommentService
	{
		ICommentDAL _commentDAL;

		public CommentManager(ICommentDAL commentDAL)
		{
			_commentDAL = commentDAL;
		}

		public void AddComment(Comment comment)
		{
			_commentDAL.Insert(comment);
		}

		public List<Comment> GetList(int id)
		{
			return _commentDAL.GetAll(x => x.ProductID == id);
		}
	}
}
