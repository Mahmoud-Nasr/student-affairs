using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meth_Portal.Models
{
    public class DoctorDashboardViewModel
    {
        public string DoctorName { get; set; }
        public List<CourseViewModel> Courses { get; set; }


    }
    public class CourseViewModel {

        public string CourseName { get; set; }
        public DateTime CourseTime { get; set; }
        public string CourseDate { get; set; }
        public string CourseCode { get; set; }

    }
}