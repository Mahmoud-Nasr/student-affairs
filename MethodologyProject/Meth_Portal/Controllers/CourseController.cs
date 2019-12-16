using Meth_Data.Database;
using Meth_Portal.implemented;
using Meth_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meth_Portal.Controllers
{
    
    public class CourseController : Controller
    {
        private courseOperations operation =new courseOperations();
        public CourseController ()
        {
        }
        
        // GET: course
        public ActionResult Index()
        {
            List<Course> list=operation.GetAllCourses();
            
            return View(list);
        }

        // GET: course/Details/5
        public ActionResult Details(int id)
        {
            Course Result = operation.GetCourseById(id);
            return View(Result);
        }

        // GET: course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: course/Create
        [HttpPost]
        public ActionResult Create(Course collection)
        {
            try
            {
                // TODO: Add insert logic here
              int result=  operation.AddCourse(collection);
                


                return RedirectToAction("Index");
            }
            catch(Exception e )
            {
                return View(collection);
            }
        }

        // GET: course/Edit/5
        public ActionResult Edit(int id)
        {
            Course Result = operation.GetCourseById(id);
            return View(Result);
        }

        // POST: course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course collection)
        {
            try
            {
                // TODO: Add update logic here
                operation.UpdateCourse(collection);
                return RedirectToAction("Index");

            }
            catch
            {
                return View(collection);
            }
        }

        // GET: course/Delete/5
        public ActionResult Delete(int id)
        {
            Course result = operation.GetCourseById(id);
            return View(result);
        }

        // POST: course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Course collection)
        {
            try
            {

                // TODO: Add delete logic here
                operation.DeleteCourse(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
