using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrendOl.Common;
using TrendOl.Entities;

namespace TrendOl.WebApp.Init
{
	public class WebCommon : ICommon
	{
		public string GetCurrentUsername()
		{
			if(HttpContext.Current.Session["login"] != null)
			{
				MyUser user = HttpContext.Current.Session["login"] as MyUser;
				return user.Username;
			}

			return "system";
		}
	}
}