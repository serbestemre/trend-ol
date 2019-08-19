using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrendOl.WebApp.ViewModels
{
	public class RegisterViewModel
	{

		[
			DisplayName("Username"),
			Required(ErrorMessage = "{0} cannot be empty."),
			MaxLength(25),MinLength(3)
		]
		public string Username { get; set; }

		[DisplayName("Email"),
			Required(ErrorMessage = "{0} cannot be empty."),
			DataType(DataType.EmailAddress)
		]

		public string Email { get; set; }

		[
			DisplayName("Password"),
			Required(ErrorMessage = "{0} cannot be empty."),
			MaxLength(25), MinLength(6),
			DataType(DataType.Password)
		]

		public string Password { get; set; }

		[
			DisplayName("RePassword"),
			Required(ErrorMessage = "{0} cannot be empty."),
			MaxLength(25), MinLength(3),DataType(DataType.Password),
			Compare("Password", ErrorMessage ="{0} and {1} does not match")
		]
		public string RePassword { get; set; }

	}
}

