using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("Wishlists")]
	public class Wishlist
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Title { get; set; }
		
		[Required]
		public virtual MyUser Owner { get; set; }
		public virtual List<Product> Products { get; set; }

	}
}
