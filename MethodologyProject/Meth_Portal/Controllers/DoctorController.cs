using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Meth_Data.Database;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Meth_Portal.Models;
using Meth_Portal.implemented;
using System.IO;

namespace Meth_Portal.Controllers
{
    public class DoctorController : Controller
    {
        private MethProjectEntities db = new MethProjectEntities();
        private readonly courseOperations course_operations;

        public DoctorController()
        {
            course_operations = new courseOperations();
        }

        // GET: Doctor
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            AspNetUser user = db.AspNetUsers.Find(userId);
            DoctorDashboardViewModel doc = new DoctorDashboardViewModel();
            doc.DoctorName = user.DoctorInfo.Degree+" "+ user.UserName;
            ((DayOfWeek)1).ToString();
            doc.Courses = user.DoctorInfo.Courses.Select(c => new CourseViewModel { CourseCode = c.CourseCode, CourseDate = ((DayOfWeek)int.Parse(c.CourseDays)).ToString(), CourseName = c.CourseName, CourseTime = c.CourseTime.Value }).ToList();
            return View(doc);
        }

        public ActionResult SelectCourse() {

            ViewBag.CourseList = course_operations.GetAllCourses();
            return View();
        }

        public ActionResult ExportClientsListToCSV(int value)
        {

            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Student ID\",\"Full Name\",\"Midterm Degree\",\"Section Degree\",\"Lecture Degree\",\"Total Degree\",");
            List<Course> dataset = course_operations.GetAllCourses().Where(x => x.ID == value).ToList();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename="+ dataset.First().CourseCode + ".csv");
            Response.ContentType = "text/csv";


            foreach (StudentCours line in dataset[0].StudentCourses)
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},",
                                           line.StudentID,
                                           line.StudentInfo.AspNetUsers.First().UserName,
                                           line.YearDegree.MidtermDegree,
                                           line.YearDegree.SectionDegree,
                                           line.YearDegree.LectureDegree,
                                           line.YearDegree.Total));
            }

            Response.Write(sw.ToString());

            Response.End();
            return RedirectToAction("SelectCourse");
        }

        public ActionResult UploadFileCsv()
        {
            return View(new List<StudentCours>());
        }

        [HttpPost]
        public ActionResult UploadFileCsv(HttpPostedFileBase postedFile)
        {
            List<StudentCours> result = new List<StudentCours>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string code= Path.GetFileName(postedFile.FileName).Split('.')[0];
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        string splited = row.Trim().Split(',')[0];
                        try
                        {
                            int id = Int32.Parse(splited);
                            List<StudentCours> temp = db.StudentCourses.Where(x => x.StudentID == id && x.Course.CourseCode.Equals(code)).ToList();
                            result.AddRange(temp);
                        }
                        catch (Exception)
                        {

                         
                        }
                    }
                }
            }
            //use result to do any operation on obbject from csv file
            return View(result.Distinct());
        }
    }
}