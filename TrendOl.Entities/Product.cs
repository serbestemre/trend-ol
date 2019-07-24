using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("Products")]

	public class Product
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		[Required]
		public int Stock { get; set; }
		[Required]
		public double Price { get; set; }
		public int DiscountPercentage { get; set; }


		public virtual Brand ProductOwner { get; set; }
		public virtual Category Category { get; set; }
		public virtual Wishlist Wishlist { get; set; }
		public virtual Rating Rating { get; set; }
		public virtual Sale_Details SaleDetails { get; set; }
		public virtual List<Product_Image> ProductImages { get; set; }
		public virtual List<Comment> Comments { get; set; }



	}
}
