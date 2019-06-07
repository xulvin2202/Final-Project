using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MainMenu()
        {
            var model = new EcommerceDao().ListByGroupId(1);
            return PartialView(model);
        }
        public ActionResult MainCategory()
        {
            var model = new EcommerceDao().ListAllMainCategory();
            return PartialView(model);
        }
    }
}