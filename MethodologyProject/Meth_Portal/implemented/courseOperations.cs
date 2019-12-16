using Meth_Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meth_Portal.implemented
{
    public class courseOperations
    {
        private readonly MethProjectEntities con;

        public courseOperations() {

            con = new MethProjectEntities();
        }




        public int AddCourse(Course val) {
            val = con.Courses.Add(val);
            con.SaveChanges();
            return val.ID;
        }

        public void UpdateCourse(Course val)
        {
            var result = con.Courses.Find(val.ID);
            con.Entry(result).CurrentValues.SetValues(val);
            con.SaveChanges();
        }
        public void DeleteCourse(Course val)
        {
            var result =con.Courses.FirstOrDefault(c => c.ID == val.ID);
            con.Courses.Remove(result);
            con.SaveChanges();
        }
        public Course GetCourseById(int Id)
        {
            return con.Courses.FirstOrDefault(x => x.ID == Id);
        }
        public List<Course> GetAllCourses()
        {
            List<Course> list;
            if (con.Courses.Count() == 0)
            {
                list = new List<Course>();
            }
            else
            {
                list = con.Courses.ToList();
            }
            return list;
        }
        public List<Course> GetAllCoursesOpened()
        {
            List<Course> list;
            if (con.Courses.Count() == 0)
            {
                list = new List<Course>();
            }
            else
            {
                list = con.Courses.Where(x => x.IsOpen == true).ToList();
            }
            return list;
        }
        public List<Course> GetAllCoursesbyLevel(string level)
        {

            List<Course> list;
            if (con.Courses.Count() == 0)
            {
                list = new List<Course>();
            }
            else
            {
                list = con.Courses.Where(x => x.CourseLevels.Equals(level)).ToList();
            }
            return list;
        }


    }
}