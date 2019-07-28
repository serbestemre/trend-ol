using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	public class Wishlist_Products
	{
		public int Id { get; set; }

		


		[Required]
		public virtual Product Product { get; set; }

		public virtual Wishlist Wishlist { get; set; }


	}
}
