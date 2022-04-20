using AhsanTest.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AhsanTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataAccessLayer dbhandle = new DataAccessLayer();
        public ActionResult Index()
        {
           
            ModelState.Clear();
            return View(dbhandle.GetAllProduct());
        }

        public JsonResult Search(string search)
        {
            ModelState.Clear();
            //JavaScriptSerializer ser=new JavaScriptSerializer();
              var model=dbhandle.Search(search);

            return Json(model, JsonRequestBehavior.AllowGet);

        }
    }
}