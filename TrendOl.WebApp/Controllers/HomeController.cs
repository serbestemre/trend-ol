using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrendOl.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
			TrendOl.BusinessLayer.Test test = new BusinessLayer.Test();
			//test.InsertTest();
			//test.UpdateTest();
			//test.DeleteTest();
			//test.CommentTest();
            return View();
        }
    }
}