using Meth_Portal.implemented;
using Meth_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meth_Data.Database;

namespace Meth_Portal.Controllers
{
    public class AspUserController : Controller
    {
        private readonly UserOperations operations;
        public AspUserController() {
            operations = new UserOperations();
            

        }
        // GET: AspUser
        public ActionResult Index()
        {
  


            List<AspNetUser> model = operations.GetAllUsers() ;
            //model.Role=operations.GetAllUsersRoles();

            return View(model);
        }

        // GET: AspUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AspUser/Create
        public ActionResult Create()
        {
            ViewBag.Roles = operations.GetAllUsersRoles();

            return View();
        }

        // POST: AspUser/Create
        [HttpPost]
        public ActionResult Create(UserViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                AspNetUser user = new AspNetUser();
                user.AccessFailedCount = collection.AccessFailedCount;
                user.DoctorID = collection.DoctorID;
                user.Email= collection.Email;
                user.EmailConfirmed = collection.EmailConfirmed;
                user.LockoutEnabled = collection.LockoutEnabled;
                user.PasswordHash = collection.PasswordHash;
                user.PhoneNumber = collection.PhoneNumber;
                user.PhoneNumberConfirmed = collection.PhoneNumberConfirmed;
                user.ProfilePic = collection.ProfilePic;
                user.SecurityStamp = collection.SecurityStamp;
                user.StudentID = collection.StudentID;
                user.TwoFactorEnabled = collection.TwoFactorEnabled;
                user.UserName = collection.UserName;
                user.Id = collection.Id;
                operations.AddAspUser(user);
                return RedirectToAction("Index");
            }
            catch(Exception exc)
            {
                return View();
            }
        }

        // GET: AspUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AspUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AspUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AspUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
