using BCShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BCShop.ViewComponents
{
	public class CommentList : ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					Id=1,
					UserName="Mustafa"

				},
				new UserComment
				{
					Id=1,
					UserName="Mustafa"

				},
			};
			return View();
		}
	}
}
