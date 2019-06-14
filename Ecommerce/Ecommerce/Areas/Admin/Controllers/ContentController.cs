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
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,Description,Detail,Image,CreateDate,CreateBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Content_Category_ID,Status")]Content content, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new ContentDao();

                    
                    var    filename = "";
                    var path = "";
                    if (image != null)
                    {
                        //filename =image.FileName; 
                        //path = Path.Combine(Server.MapPath("~/Image/"), filename);
                        ////Luu ý chỗ này hơi sai á
                        //image.SaveAs(path);
                        //content.Image = filename;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") +image.FileName;
                        path = Path.Combine(Server.MapPath("~/Image"), filename);
                        image.SaveAs(path);
                        content.Image = filename; //Luu ý
                    }
                    //else 
                    //{
                    //    //image.SaveAs(path);
                    //    content.Image = "logo.png";
                    //}
                    content.Name = content.Name;
                    content.CreateDate = Convert.ToDateTime(DateTime.UtcNow.ToLocalTime());
                    content.MetaTitle = Functions.ConvertToUnSign(content.Name);
                    content.Description = content.Description;
                    content.Detail = content.Detail;
                    content.Content_Category_ID = content.Content_Category_ID;
                    content.Status = Convert.ToBoolean(true);
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