using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendOl.WebApp.ViewModels
{
	public class OkViewModel:NotifyViewBase<string>
	{
		public OkViewModel()
		{
			Title = "Process Completed Successfully";     
		}
	}
}