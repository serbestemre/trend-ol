﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("Ratings")]
	public class Rating
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int LikeNumber { get; set; }
		public int DislikeNumber { get; set; }

		public virtual MyUser Voter { get; set; }
		[Required]
		public virtual Product Product { get; set; }
	}
}
