using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? seletedID = null)
        {
            var dao = new Model.Dao.EcommerceDao();
            ViewBag.MainCategory_ID = new SelectList(dao.ListAllCategory(), "ID", "Name", seletedID);
        }
    }
}