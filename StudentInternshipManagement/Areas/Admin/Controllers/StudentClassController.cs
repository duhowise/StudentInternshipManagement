﻿using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Models.Entities;
using Services.Interfaces;
using StudentInternshipManagement.Controllers;

namespace StudentInternshipManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentClassController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IStudentClassService _studentClassService;

        public StudentClassController(IStudentClassService studentClassService, IDepartmentService departmentService)
        {
            _studentClassService = studentClassService;
            _departmentService = departmentService;
        }

        public ActionResult Index()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }

        public ActionResult StudentClasses_Read([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = _studentClassService.GetAll().ToDataSourceResult(request, studentClass => new
            {
                studentClass.Id,
                studentClass.ClassName,
                studentClass.DepartmentId
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentClasses_Create([DataSourceRequest] DataSourceRequest request,
            StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                _studentClassService.Add(studentClass);
            }

            return Json(new[] {studentClass}.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentClasses_Update([DataSourceRequest] DataSourceRequest request,
            StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                _studentClassService.Update(studentClass);
            }

            return Json(new[] {studentClass}.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentClasses_Destroy([DataSourceRequest] DataSourceRequest request,
            StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                _studentClassService.Delete(studentClass);
            }

            return Json(new[] {studentClass}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetStudentList(int classId, [DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = _studentClassService.GetById(classId).Students.ToDataSourceResult(request,
                student => new
                {
                    StudentId = student.Id,
                    student.StudentCode,
                    student.StudentName,
                    student.BirthDate,
                    student.Address,
                    student.Phone,
                    student.Cpa,
                    student.ClassId
                });

            return Json(result);
        }
    }
}