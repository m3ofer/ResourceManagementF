using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ResourceManagementF.Models;
using ResourceManagementF.DataLayer;

namespace ResourceManagementF.Controllers
{
    public class LogController : Controller
    {
        DataContext db = new DataContext();

        // GET: Log
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProcessLogin(Login log) 
        {
            bool a = false;
            foreach(var item in db.Enseignants)
            {
                if(item.Email == log.Email && item.Password == log.Password)
                {
                    Session["pass"] = item.Id;
                    return RedirectToAction("Index", "User");
                }
                a = true;
            }

            foreach (var item in db.Administratifs)
            {
               if (item.Email == log.Email && item.Password == log.Password && item.Isresp == true)
                {
                    Session["pass"] = item.Id;
                    return RedirectToAction("Index", "Home");
                }
                a = true;
            }
            foreach (var item in db.Services)
            {
                if (item.Email == log.Email && item.Password == log.Password)
                {
                    return RedirectToAction("Services", "User");
                }
                a = true;
            }
            if (a == true)
            {
                ViewBag.message = "your password or email are wrong";
            }
            return View("Index");
        }
    }
}