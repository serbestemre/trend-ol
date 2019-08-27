using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendOl.WebApp.ViewModels
{
	public class InfoViewModel:NotifyViewBase<string>
	{
		public InfoViewModel()
		{
			Title = "Info";
		}
	}
}