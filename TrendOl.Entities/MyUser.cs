using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendOl.Entities
{
	[Table("MyUsers")]

	public class MyUser
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Surname { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Email { get; set; }
		public string UserImage { get; set; }

		public bool IsSuperUser { get; set; }
		public bool HasBrand { get; set; }
		public bool IsActive { get; set; }
		public Guid ActivateGuid { get; set; }
		public virtual List<Comment> Comments { get; set; }
		
		//public virtual Wishlist Wishlist { get; set; }
		public virtual List<Like> Likes { get; set; }
		public virtual List<Sale> Sales { get; set; }

	}
}
