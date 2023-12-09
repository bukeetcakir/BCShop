using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Entity.Concrete
{
	public class User
	{
		[Key]
		public int UserID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Status { get; set; }
		public List<Comment> Comments { get; set; }
	}
}
