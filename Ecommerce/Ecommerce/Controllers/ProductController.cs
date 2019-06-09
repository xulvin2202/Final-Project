using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new EcommerceDao().ListAllCategory();
            return PartialView(model);
        }
        public ActionResult Category(long id)
        {
            var category = new EcommerceDao().ViewDetail(id);
            return View(category);
        }
       public ActionResult Detail(long id)
        {
            var product = new EcommerceDao().ViewDetail(id);
            ViewBag.Category = new EcommerceDao().ViewDetail(product.Category_ID.Value);
            ViewBag.RelatedProducts = new EcommerceDao().ListRelatedProducts(id);
            return View(product);
        }
    }
}