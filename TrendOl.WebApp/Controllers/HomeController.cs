using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendOl.BusinessLayer;
using TrendOl.Entities;
using TrendOl.Entities.ValueObjects;

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

			if (ModelState.IsValid)
			{
				MyUserManager user_manager = new MyUserManager();
				BusinessLayerResult<MyUser> res = user_manager.LoginUser(model);

				if (res.Errors.Count > 0)
				{
					res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));




					return View(model);
				}

				Session["login"] = res.Result; // SESSION
				return RedirectToAction("Index");

			}

			return View(model);
		}


		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterViewModel model)
		{

			if (ModelState.IsValid)
			{
				MyUserManager myUserManager = new MyUserManager();
				BusinessLayerResult<MyUser> result = myUserManager.RegisterUser(model);

				if (result.Errors.Count > 0)
				{
					result.Errors.ForEach(x => ModelState.AddModelError("",x.Message));
					return View(model);
				}


				

				return RedirectToAction("RegisterOk");
			}

			// TODO List
			// username control-
			// email control-
			// insert user
			// activation e-mail

			return View(model);
		}


		public ActionResult UserActivate(Guid activate_id)
		{
			//user activation
			return View();
		}

		public ActionResult RegisterOk()
		{
			return View();
		}

		public ActionResult Logout()
		{
			return View();
		}
	}
} 