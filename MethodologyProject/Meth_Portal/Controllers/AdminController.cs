using Meth_Data.Database;
using Meth_Portal.implemented;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meth_Portal.Controllers
{
    public class AdminController : Controller
    {
        studentOperations student_operation = new studentOperations();
        AdminOperation admin_operation = new AdminOperation();
        // GET: Admin
        public ActionResult Index()
        {
            List<StudentCours> result = student_operation.GetAllStudentCourses(0);
            if (result == null)
            {
                result = new List<StudentCours>();
            }
            return View(result);
        }
       
        public ActionResult Main()
        {

            return View();
        } 

        [HttpGet]
        public ActionResult EditCourse(int Id)
        {
            StudentCours result = student_operation.GetStudentCourseById(Id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditCourse(StudentCours result)
        {
            student_operation.EditStudentCourse(result);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DeleteCourse(int Id)
        {

            StudentCours result = student_operation.GetStudentCourseById(Id);
            return View(result);
        }
        [HttpPost]
        public ActionResult DeleteCourse(StudentCours val)
        {
            try
            {
                student_operation.DeleteStudentCourse(val);
            }
            catch (Exception)
            {

                return View(val);
            }


            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult lookforStudentCourses()
        {

            return View();
        }
        [HttpPost]
        public ActionResult lookforStudentCourses(int Search_val)
        {

            List<StudentCours> result = student_operation.GetAllStudentCourses(Search_val);
            if (result == null)
            {
                result = new List<StudentCours>();
            }
            return View("Index",result);
        }

        public ActionResult StudentList()
        {
            List<StudentInfo> result= admin_operation.GetAllStudents();
            return View(result);
        }
    }
}