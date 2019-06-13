using Ecommerce.Help;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        private EcommerceDbContext db = new EcommerceDbContext();
        // GET: Admin/Content
        public ActionResult Index()
        {
            var dao = new UserDao();
            var model = dao.ListAllContent();
           
            return View(model);
            //return View(contents.ToList());
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
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,Description,Detail,Image,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription")]Content content, HttpPostedFileBase image)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    var dao = new ContentDao();
                    var a = new Content();

                    
                    if (image != null)
                    {
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + image.FileName;
                        path = Path.Combine(Server.MapPath("~/Image/"), filename);
                        image.SaveAs(path);
                        a.Image = filename; //Luu ý
                    }
                    else
                    {
                        a.Image = "logo.png";
                    }
                    a.Name = content.Name;
                    a.CreateDate = Convert.ToDateTime(DateTime.Now.ToString());
                    a.MetaTitle = Functions.ConvertToUnSign(content.Name);
                    a.Description = content.Description;
                    a.Detail = content.Detail;
                    a.Status = true;
                    var id = dao.Insert(content);
                    if (id > 0)
                    {
                        SetAlert("Thêm mới thành thành công", "success");
                        ViewBag.Success = "Thêm thành công";
                        content = new Content();
                        return RedirectToAction("Index", "Content");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới ko thành công");
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            SetViewBag();
            return View(content);
        }
        public void SetViewBag(long? seletedID = null)
        {
            var dao = new Model.Dao.EcommerceDao();
            ViewBag.Content_Category_ID = new SelectList(dao.ListAllContent(),"ID","Name",seletedID);

        }
    }
}