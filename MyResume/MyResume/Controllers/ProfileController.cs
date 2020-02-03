using MyResume.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyResume.Controllers
{
    public class ProfileController : Controller
    {
        SqlConnection dbcon = new SqlConnection(
         ConfigurationManager.ConnectionStrings["ProfileDB"].ConnectionString.ToString());

        // GET: Profile

        public ActionResult Index()
            {
            
                List<MyProfile> profileList;
                 try
                 {
                dbcon.Open();
                profileList = MyProfile.GetProfileList(dbcon, "");
                dbcon.Close();
            }
                catch (Exception ex) { throw new Exception(ex.Message); }
                return View(profileList);
            }
        public ActionResult Details(string id)
        {
            if (id.Length > 0)
            {
                try
                {
                    dbcon.Open();
                    MyProfile profile = MyProfile.GetProfileSingle(dbcon, id.ToString());
                    dbcon.Close();
                    return View(profile);
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            ViewBag.errormsg = "Invalid data in the Details Page";
            return View("Error");
        }
    
            public ActionResult Create()
            {
            MyProfile profile = new MyProfile();
            return View(profile);
            }
        [HttpPost]
            public ActionResult Create(MyProfile profile)
            {
            if (ModelState.IsValid)
            {
                try
                {
                    dbcon.Open();
                    int result = MyProfile.CUDProfile(dbcon, "create", profile);
                    dbcon.Close();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            } //valid data
            ViewBag.errmsg = "Data validation error in Create method";
            return View("Error");

            }
        public ActionResult Edit(string id)
        {
            if (id.Length > 0)
            {
                try
                {
                    dbcon.Open();
                    MyProfile profile = MyProfile.GetProfileSingle(dbcon, id.ToString());
                    dbcon.Close();
                    return View(profile);
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            ViewBag.errormsg = "Invalid data in the Edit Page";
            return View("Error");
        }
        [HttpPost]
        public ActionResult Edit(MyProfile profile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   dbcon.Open();
                    int result = MyProfile.CUDProfile(dbcon, "update", profile);
                    dbcon.Close();
                    return RedirectToAction("Index");
                }

                catch (Exception ex) { throw new Exception(ex.Message); }
            } //valid data
            ViewBag.errmsg = "Data validation error in Edit method";
            return View("Error");
        }
        public ActionResult Delete(string id)
        {
            if (id.Length > 0)
            {
                try
                {
                    dbcon.Open();
                    MyProfile profile = MyProfile.GetProfileSingle(dbcon, id);
                    dbcon.Close();
                    return View(profile);
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            ViewBag.errormsg = "Invalid data in the Delete Page";
            return View("Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, FormCollection fc)
        {
            MyProfile profile = new MyProfile();
            profile.Id = id;
            try
            {
                dbcon.Open();
                int result = MyProfile.CUDProfile(dbcon, "delete", profile);
                dbcon.Close();
                return RedirectToAction("Index");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}