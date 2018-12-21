﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Models;
using Services;
using Services.Implements;

namespace StudentInternshipManagement.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    public class ProfileController : Controller
    {
        private readonly StudentService _service = new StudentService();
        // GET: Student/Profile
        public ActionResult Index()
        {
            var id = User.Identity.GetUserName();
            var student = _service.GetById(id);
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ViewBag.Email = userManager.FindByName(id).Email;
            return View(student);
        }

        public ActionResult Edit()
        {
            var id = User.Identity.GetUserName();
            var student = _service.GetById(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, global::Models.Entities.Student model)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Images/avatars/"), $"{model.StudentId}{extension}");
                    file.SaveAs(physicalPath);
                    model.Avatar = $"{model.StudentId}{extension}";
                }

                ViewBag.Message = _service.Update(model) ? "Thành công" : "Thất bại";
            }

            return RedirectToAction("Index");
        }
    }
}