using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrendOl.BusinessLayer;
using TrendOl.Entities;

namespace TrendOl.WebApp.Controllers
{
    public class ShoppingController : Controller
    {
		
		public ActionResult Shopping()
		{

			ProductManager pm = new ProductManager();
			return View(pm.GetAllProducts());
		}

		public ActionResult ByCategory(int? id)
		{
			if(id == null)
			{
				
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			

			SubCategoryManager sm = new SubCategoryManager();

			SubCategory subCat = sm.GetSubCategoryById(id.Value);

			if(subCat == null)
			{
				return HttpNotFound();
			}
			return View("Shopping",subCat.Products);
		}
	}
}