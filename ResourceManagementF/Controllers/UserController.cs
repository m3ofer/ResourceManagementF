using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ResourceManagementF.Models;
using ResourceManagementF.DataLayer;
using System.Data.SqlClient;

namespace ResourceManagementF.Controllers
{
    public class UserController : Controller
    {
        DataContext db = new DataContext();
        // GET: User
        public ActionResult Index()
        {
            int pass = (int)Session["pass"];

            var st = db.Affectation_Comp_Teacher
                    .Include("Profs")
                    .Include("Computers")
                    .Where(s => s.Affecter == true)
                    .Where(s => s.Profs.Id == pass);
            return View(st);
        }
        public ActionResult printers()
        {
            int pass = (int)Session["pass"];
            var st = db.Affectation_Print_Teacher
                    .Include("Profs")
                    .Include("Printers")
                    .Where(s => s.Affecter == true)
                    .Where(s => s.Profs.Id == pass);
            return View(st);
        }
        public ActionResult Details(int? id)
        {
            int test = db.Database
                .ExecuteSqlCommand("Update AcompTs set Panne='1' where Id=@id", new SqlParameter("@id",id));
            return RedirectToAction("Index","User");
        }
        public ActionResult Detail(int? id)
        {
            int test = db.Database
                .ExecuteSqlCommand("Update AprintTs set Panne='1' where Id=@id", new SqlParameter("@id", id));
            return RedirectToAction("Index", "User");
        }
        public ActionResult Services()
        {
            var st = db.Affectation_Comp_Teacher
                    .Include("Profs")
                    .Include("Computers")
                    .Where(s => s.Panne == true)
                    .Where(s => s.Affecter == true);
            return View(st);
        }
        public ActionResult Fixed(int? id)
        {
            int test = db.Database
                .ExecuteSqlCommand("Update AcompTs set Panne='0' where Id=@id", new SqlParameter("@id", id));
            return RedirectToAction("Services", "User");
        }
    }
}