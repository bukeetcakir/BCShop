using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.ViewComponents.Comment
{
	public class CommentListByProduct:ViewComponent
	{
		CommentManager cm = new CommentManager(new EFCommentRepository());
		public IViewComponentResult Invoke(int id)
		{
			var values = cm.GetList(id);
			return View(values);
		}
	}
}
