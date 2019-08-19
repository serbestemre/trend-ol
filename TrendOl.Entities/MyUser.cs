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
		
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Gender { get; set; }
		public string Address { get; set; }

		[Required, MaxLength(25), MinLength(3)]
		public string Username { get; set; }
		[Required, MaxLength(25), MinLength(6)]
		public string Password { get; set; }
		[Required,DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		public string UserImage { get; set; }

		public bool IsSuperUser { get; set; }
		public bool HasBrand { get; set; }
		public bool IsActive { get; set; }
		public Guid ActivateGuid { get; set; }
		public virtual List<Comment> Comments { get; set; }
		
		//public virtual Wishlist Wishlist { get; set; }
		public virtual List<Rate> Likes { get; set; }
		public virtual List<Sale> Sales { get; set; }

	}
}
