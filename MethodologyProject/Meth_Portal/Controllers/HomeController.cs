using Meth_Data.Database;
using Meth_Portal.implemented;
using Meth_Portal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meth_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly studentOperations student_operations;
        private readonly courseOperations course_operations;
        public HomeController()
        {
            student_operations = new studentOperations();
            course_operations = new courseOperations();
        }
      
       
        public ActionResult StudentTimeTable() {
             
            //model.Course = new List<Meth_Data.Database.Course>();
            List<StudentCours> result= student_operations.GetAllStudentCourses(1);
            if (result == null)
            {
                result = new List<StudentCours>();
            }
                return View(result);
        

        }
        public ActionResult Index()
        {
            //model.Course = new List<Meth_Data.Database.Course>();
            List<StudentCours> result= student_operations.GetAllStudentCourses(1);
            ViewBag.hours = student_operations.AllstudentHours(1);
            ViewBag.Gpa = String.Format("{0:F2}", student_operations.StudentGpa(1)); 
            if (result == null)
            {
                result = new List<StudentCours>();
            }
                return View(result);
        }
        public ActionResult TestTemp()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisteCourse()
        {
            ViewBag.CourseID = course_operations.GetAllCoursesOpened();
            return View();
        }
        [HttpGet]
        public ActionResult DetailsCourse(int Id)
        {
            StudentCours result = student_operations.GetStudentCourseById(Id);
            return View(result);
        }
        //[HttpPost]
        //public ActionResult EditCourse(StudentCours result)
        //{
        //    student_operations.EditStudentCourse(result);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult RegisteCourse (StudentCours collection)
        {
            try
            {
                collection.StudentID = 1;
                student_operations.RegisterCourse(collection);

                ViewBag.CourseID = course_operations.GetAllCourses();
            }
            catch (Exception e)
            {
                return View();
            }
            // need to be assigned from session for logged in student 
           

            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public ActionResult DeleteCourse(int Id) {

        //    StudentCours result = operations.GetStudentCourseById(Id);
        //    return View(result);
        //}
        //[HttpPost]
        //public ActionResult DeleteCourse(StudentCours val)
        //{
        //    try
        //    {
        //        operations.DeleteStudentCourse(val);
        //    }
        //    catch (Exception)
        //    {

        //        return View(val);
        //    }
            

        //    return RedirectToAction("Index");
        //}

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}