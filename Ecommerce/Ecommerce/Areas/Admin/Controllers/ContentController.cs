using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
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
        public ActionResult Edit(long id)
        {
            var dao = new EcommerceDao();
            var content = dao.GetByID(id);
            SetViewBag(content.Content_Category_ID);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(model.Content_Category_ID);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content content)
        {
            if(ModelState.IsValid)
            {

            }
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? seletedID = null)
        {
            var dao = new Model.Dao.EcommerceDao();
            ViewBag.Content_Category_ID = new SelectList(dao.ListAllContent(),"ID","Name",seletedID);
        }
    }
}