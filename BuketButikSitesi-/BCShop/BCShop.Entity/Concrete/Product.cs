using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Entity.Concrete
{
	public class Product
	{
		[Key]
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Properties { get; set; }
		public double Price { get; set; }
		public string ImageUrl { get; set; }
		public string Note { get; set; }
		public int Amount { get; set; }
		public bool Status { get; set; }

		public int CategoryID { get; set; }
		public Category Category { get; set; }
        public List<Comment> Comments{ get; set; }


    }
}
