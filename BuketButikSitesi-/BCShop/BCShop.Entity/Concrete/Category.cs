using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Entity.Concrete
{
	public class Category
	{
		[Key]
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
		public List<Product> Products { get; set; }
	}
}
