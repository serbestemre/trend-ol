using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendOl.BusinessLayer;



namespace TrendOl.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
		public ActionResult Index()
		{
			Test test = new Test();

		
			
			return View();
		}

		

	}
}