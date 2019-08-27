using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendOl.BusinessLayer;
using TrendOl.Entities;
using TrendOl.Entities.Messages;
using TrendOl.Entities.ValueObjects;
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


				OkViewModel notifyObj = new OkViewModel();
				notifyObj.Title = "Registiration is Successfully Done!";
				notifyObj.Items.Add("Please go to your e-mail address and activate your account by clicking the activation link.");


				return View("Ok",notifyObj);
			}

			// TODO List
			// username control-
			// email control-
			// insert user
			// activation e-mail

			return View(model);
		}

		public ActionResult UserActivate(Guid id)
		{
			//user activation

			MyUserManager userManager = new MyUserManager();
			BusinessLayerResult<MyUser> result = userManager.ActivateUser(id);

			if (result.Errors.Count > 0)
			{
				ErrorViewModel errorNotifyObj = new ErrorViewModel()
				{
					Title = "Wrong Attempt",
					Items = result.Errors,
				};

				return View("Error", errorNotifyObj);
			}

			OkViewModel okNotifyObj = new OkViewModel();
			okNotifyObj.Title = "Account is Activated";
			okNotifyObj.RedirectingUrl = "/Home/Login";
			okNotifyObj.Items.Add("Welcome to TrendOl family. We wish you have great enjoy during the shopping!");

			return View("Ok",okNotifyObj);
		}

		public ActionResult Logout()
		{
			Session.Clear();
			return  RedirectToAction("Index");
		}

		public ActionResult ShowProfile()
		{

			MyUser currentUser = Session["login"] as MyUser;
			MyUserManager myUserManager = new MyUserManager();
			BusinessLayerResult<MyUser> res = myUserManager.GetUserById(currentUser.Id);

			if (res.Errors.Count > 0)
			{
				ErrorViewModel errorNotifyObj = new ErrorViewModel()
				{
					Title = "Error Occurred",
					Items = res.Errors
				};
				return View("Error", errorNotifyObj);
				

			}

			return View(res.Result);
		}

		public ActionResult TestNotify()
		{
			ErrorViewModel model = new ErrorViewModel()
			{
				Header = "Yönlendirme..",
				Title = "Error Test",
				RedirectingTimeout = 7000,
				Items = new List<ErrorMessageObj> { new ErrorMessageObj() { Message = "Test başarılı 1" }, new ErrorMessageObj() { Message = "Test başarılı 2" } }

			};
			return View("Error", model);
		}

		public ActionResult EditProfile()
		{


			MyUser currentUser = Session["login"] as MyUser;
			MyUserManager myUserManager = new MyUserManager();
			BusinessLayerResult<MyUser> res = myUserManager.GetUserById(currentUser.Id);

			if (res.Errors.Count > 0)
			{
				ErrorViewModel errorNotifyObj = new ErrorViewModel()
				{
					Title = "Error Occurred",
					Items = res.Errors
				};
				return View("Error", errorNotifyObj);


			}



			return View(res.Result);
		}

		[HttpPost]
		public ActionResult EditProfile(MyUser model, HttpPostedFileBase UserImage)
		{
			ModelState.Remove("ModifiedUsername");
			if (ModelState.IsValid)
			{
				if (UserImage != null && (
				UserImage.ContentType == "image/jpeg" ||
				UserImage.ContentType == "image/jpg" ||
				UserImage.ContentType == "image/png"))
				{
					string filename = $"user_{ model.Id}.{ UserImage.ContentType.Split('/')[1]}";
					UserImage.SaveAs(Server.MapPath($"~/images/avatars/{filename}"));
					model.UserImage = filename;
				}

				MyUserManager userManager = new MyUserManager();
				BusinessLayerResult<MyUser> res = userManager.UpdateProfile(model);

				if (res.Errors.Count > 0)
				{
					ErrorViewModel errorNotifyObj = new ErrorViewModel()
					{
						Items = res.Errors,
						Title = "Profile could not updated",
						RedirectingUrl = "/Home/EditProfile"
					};
					return View("Error", errorNotifyObj);
				}

				Session["login"] = res.Result; // Session updated.



				return RedirectToAction("ShowProfile");
			}
			else
			{
				return View(model);
			}
		}


		public ActionResult DeleteProfile()
		{
			MyUser currentUser = Session["login"] as MyUser;
			MyUserManager userManager = new MyUserManager();
			BusinessLayerResult<MyUser> res = userManager.DeleteUserById(currentUser.Id);

			if(res.Errors.Count > 0)
			{
				ErrorViewModel errorNotifyObj = new ErrorViewModel()
				{
					Items = res.Errors,
					Title = "Profile could not deleted",
					RedirectingUrl = "/Home/ShowProfile"
				};
				return View("Error", errorNotifyObj);
			}
			Session.Clear();

			return RedirectToAction("Index");
		}
	}

} 