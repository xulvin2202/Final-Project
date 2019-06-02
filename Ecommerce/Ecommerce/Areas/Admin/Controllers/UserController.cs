﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Common;
using Model.Dao;
using Model.EF;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5 )
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(user.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                if (dao.CheckUserEmail(user.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var a = new User();
                    var encrytedMd5Hash = Encryptor.MD5Hash(user.Password);
                    user.Password = encrytedMd5Hash;
                    a.Image = user.Image;
                    a.UserName = user.UserName;
                    a.Name = user.Name;
                    a.Phone = user.Phone;
                    a.Address = user.Address;
                    a.Email = user.Email;
                    a.Phone = user.Phone;
                    a.Status = true;
                    var id = dao.Insert(user);
                    if (id > 0)
                    {
                        SetAlert("Thêm thành công", "success");
                        ViewBag.Success = "Thêm thành công";
                        user = new User();
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm user ko thành công");
                    }
                }
                
            }
            return View(user);

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(!string.IsNullOrEmpty(user.Password))
                {
                    var encrytedMd5Hash = Encryptor.MD5Hash(user.Password);
                    user.Password = encrytedMd5Hash;
                }
                var a = new User();
                a.Image = user.Image;
                a.Name = user.Name;
                a.Phone = user.Phone;
                a.Address = user.Address;
                a.Email = user.Email;
                a.Phone = user.Phone;
                a.Status = true;
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa thành công", "success");
                    ViewBag.Success = "Cập nhật thành công";
                    user = new User();
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật ko thành công");
                }
            }
            return View(user);

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}