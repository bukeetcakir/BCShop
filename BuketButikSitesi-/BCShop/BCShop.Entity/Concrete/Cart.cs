using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Entity.Concrete
{
	public class Cart
	{
		public int CartID { get; set; }
		public int UserID { get; set; }

		public List<CartItem> CartItems { get; set; }
	}
}
