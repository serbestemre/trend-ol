using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendOl.WebApp.ViewModels
{
	public class NotifyViewBase<T>
	{
		public List<T> Items { get; set; }
		public string Header { get; set; }
		public string Title { get; set; }
		public bool IsRedirecting { get; set; }
		public string RedirectingUrl { get; set; }
		public int RedirectingTimeout { get; set; }

		public NotifyViewBase()
		{
			Header = "Redirecting...";
			Title = "Wrong Attempt";
			IsRedirecting = true;
			RedirectingUrl = "/Home/Index";
			RedirectingTimeout = 5000;
			Items = new List<T>();
		}

	}
}