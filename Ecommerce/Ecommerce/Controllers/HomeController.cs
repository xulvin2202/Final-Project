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
            var model = new EcommerceDao().ListSlide();
            var product = new EcommerceDao();
            ViewBag.NewProduct = product.ListNewProduct(10);
            ViewBag.FeatureProduct = product.ListFeatureProduct(10);
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new EcommerceDao().ListByGroupId(1);
            return PartialView(model);
        }
        
        [ChildActionOnly]
        public ActionResult TopMenuRight()
        {
            var model = new EcommerceDao().ListByGroupId(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopMenuLeft()
        {
            var model = new EcommerceDao().ListByGroupId(3);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new EcommerceDao().GetFooter(); 
            return PartialView(model);
        }

    }
}