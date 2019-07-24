using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("Sale")]
	public class Sale
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public DateTime Date { get; set; }
		[Required]
		public DateTime Time { get; set; }
		public double TotalPrice { get; set; }
		public double TotalVat { get; set; }

		public virtual MyUser SaleOwner { get; set; }
		public virtual Product Product { get; set; }
		public virtual List<Sale_Details> SaleDetails { get; set; }

	}
}
