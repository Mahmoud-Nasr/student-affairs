using Meth_Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meth_Portal.implemented
{
    public class AdminOperation
    {
        private readonly MethProjectEntities context;
        public AdminOperation()
        {
            context = new MethProjectEntities();
        }
        public List<StudentInfo> GetAllStudents()
        {
            return context.StudentInfoes.ToList();
        }
    }
}