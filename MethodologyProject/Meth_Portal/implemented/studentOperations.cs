using Meth_Data.Database;
using Meth_Portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Meth_Portal.implemented
{
    public class studentOperations
    {
        private readonly MethProjectEntities context;

        public studentOperations() {
            this.context = new MethProjectEntities();
        }
        public List<StudentCours> GetAllStudentCourses(int studentid) {

           List<StudentCours> registered_courses= context.StudentCourses.Where(x => x.StudentID == studentid && x.Course.IsOpen==true).ToList();
             
            return registered_courses;
        }

        public int AllstudentHours(int studentid) {
            int result = 0;
            List<StudentCours> val = context.StudentCourses.Where(x => x.StudentID == studentid).ToList();

            foreach (var item in val)
            {
                result += item.Course.CourseHours;

            }
            return result;
        }


        public Double StudentGpa(int studentid) {

            int Total_hours = 0;
            List<StudentCours> val = context.StudentCourses.Where(x => x.StudentID == studentid).ToList();
            Double Courses_grades = 0;
            foreach (var item in val)
            {
                Total_hours += item.Course.CourseHours;
                if (50<=Int32.Parse(item.YearDegree.Total)&& Int32.Parse(item.YearDegree.Total) < 60)
                {
                    Courses_grades += 1.8;
                }
                else if (60 <= Int32.Parse(item.YearDegree.Total) && Int32.Parse(item.YearDegree.Total) < 65)
                {
                    Courses_grades += 2.1;
                }else if (65 <= Int32.Parse(item.YearDegree.Total) && Int32.Parse(item.YearDegree.Total) < 70)
                {
                    Courses_grades += 2.4;
                }else if (70 <= Int32.Parse(item.YearDegree.Total) && Int32.Parse(item.YearDegree.Total) < 75)
                {
                    Courses_grades += 2.7;
                }else if (75 <= Int32.Parse(item.YearDegree.Total) && Int32.Parse(item.YearDegree.Total) < 80)
                {
                    Courses_grades += 3;
                }else if (80 <= Int32.Parse(item.YearDegree.Total) && Int32.Parse(item.YearDegree.Total) < 85)
                {
                    Courses_grades += 3.3;
                }else if (85 <= Int32.Parse(item.YearDegree.Total) && Int32.Parse(item.YearDegree.Total) < 90)
                {
                    Courses_grades += 3.7;
                }
                else if (90 <= Int32.Parse(item.YearDegree.Total) && Int32.Parse(item.YearDegree.Total) < 100)
                {
                    Courses_grades += 4;
                }
            }
            Double final = Courses_grades / val.Count();
            return final;
        }

       
        public int RegisterCourse(StudentCours val) {
            StudentCours added;
            try
            {
                YearDegree deg = new YearDegree();
                deg.LectureDegree = "0";
                deg.MidtermDegree = "0";
                deg.SectionDegree = "0";
                deg.Total = "0";
                YearDegree yearAdded = context.YearDegrees.Add(deg);
                context.SaveChanges();
                val.YearDegreeID = yearAdded.ID;
                val.FinalDegree = "0";
                 added = context.StudentCourses.Add(val);
                context.SaveChanges();

            }
            catch (Exception exe)
            {

                throw;
            }
            return added.ID;
        }

        public StudentCours GetStudentCourseById(int Id)
        {
            return context.StudentCourses.FirstOrDefault(x=>x.ID==Id);
        }

        public void EditStudentCourse(StudentCours val)
        {
            StudentCours result = context.StudentCourses.Find(val.ID);
            //context.StudentCourses.Attach(result);
            context.Entry(result).CurrentValues.SetValues(val);
            if (Int32.Parse( val.YearDegree.Total)>=100)
            {
                val.YearDegree.Total = "100";
            }
            context.Entry(result.YearDegree).CurrentValues.SetValues(val.YearDegree);

            //context.Entry(val).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void DeleteStudentCourse(StudentCours val)
        {
            StudentCours result = context.StudentCourses.Find(val.ID);

            context.YearDegrees.Remove(result.YearDegree);
            context.StudentCourses.Remove(result);
            context.SaveChanges();
        }

    }



}