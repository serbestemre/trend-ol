using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("Categories")]
	public class Category : MyEntityBase
	{
		
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }


		
		public virtual List<Product> Product { get; set; }

		public virtual List<SubCategory> SubCategories { get; set; }
}
}
