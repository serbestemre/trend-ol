using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendOl.WebApp.ViewModels
{
	public class WarningViewModel:NotifyViewBase<string>
	{
		public WarningViewModel()
		{
			Title = "Warning";

		}

	}
}