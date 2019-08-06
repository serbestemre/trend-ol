using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("Rates")]
	public class Rate
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int RatingScore { get; set; }

		[Required]
		public  virtual MyUser RateOwner { get; set; }
		[Required]
		public virtual Product Product {  get; set; }

	

	}
}
