using BCShop.Business.Concrete;
using BCShop.Data.EntityFramework;
using BCShop.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager com = new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment c)
		{
			c.Status = true;
			c.ProductID = 4;
			c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			com.AddComment(c);
			return PartialView();
		}
		public PartialViewResult CommentListByProduct(int id)
		{
			var comments = com.GetList(id);
			return PartialView(comments);
		}
	}
}
