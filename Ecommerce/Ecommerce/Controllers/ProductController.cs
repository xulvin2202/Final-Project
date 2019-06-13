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
            var model = new CategoryDao().ListAllCategory();
            return PartialView(model);
        }
        public ActionResult Category(long cateid,int pageSize=1,int page = 1)
        {
            var category = new CategoryDao().ViewDetail(cateid);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new EcommerceDao().ListByCategoryId(cateid, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;   
            ///
            //ViewBag.Brand = new EcommerceDao().ListAllBrand(cateid);
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var product = new EcommerceDao().ViewDetail(id);
            ViewBag.Category = new CategoryDao().ViewDetail(product.Category_ID.Value);
          
            ViewBag.RelatedProducts = new EcommerceDao().ListRelatedProducts(id);
            return View(product);
        }
    }
}