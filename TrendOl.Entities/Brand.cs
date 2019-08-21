using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("Brands")]
	public class Brand : MyEntityBase
	{
		[Required]
		public string BrandName { get; set; }
		public string Tag { get; set; }
		public string BrandImage { get; set; }
		
		
		public virtual MyUser MyUser { get; set; }
		public virtual List<Product> Products { get; set; }

		
	}
}
