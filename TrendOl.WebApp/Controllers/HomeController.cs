using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendOl.BusinessLayer;
using TrendOl.WebApp.ViewModels;

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

		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(LoginViewModel model)
		{
			return View();
		}


		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterViewModel model)
		{
			return View();
		}

		public ActionResult Logout()
		{
			return View();
		}
	}
} 