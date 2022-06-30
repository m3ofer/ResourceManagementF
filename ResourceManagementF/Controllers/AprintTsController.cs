using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResourceManagementF.DataLayer;
using ResourceManagementF.Models;

namespace ResourceManagementF.Controllers
{
    public class AprintTsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AprintTs
        public ActionResult Index()
        {
            return View(db.Affectation_Print_Teacher.Include("Profs").Include("Printers"));
        }

        // GET: AprintTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AprintT aprintT = db.Affectation_Print_Teacher.Find(id);
            if (aprintT == null)
            {
                return HttpNotFound();
            }
            return View(aprintT);
        }

        // GET: AprintTs/Create
        public ActionResult Create()
        {
            ViewBag.depts = db.Enseignants;
            ViewBag.prints = db.Impriments;
            return View();
        }

        // POST: AprintTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, AprintT aprintT)
        {
            try
            {
                // TODO: Add insert logic here
                int idDep = int.Parse(collection["Select1"]);
                int idPrin = int.Parse(collection["Select2"]);
                foreach (var item in db.Enseignants)
                {
                    if (item.Id == idDep)
                        item.AprintTeachersLists.Add(aprintT);
                }
                foreach (var item in db.Impriments)
                {
                    if (item.Id == idPrin)
                        item.APrintTList.Add(aprintT);
                }
                db.Affectation_Print_Teacher.Add(aprintT);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AprintTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AprintT aprintT = db.Affectation_Print_Teacher.Find(id);
            if (aprintT == null)
            {
                return HttpNotFound();
            }
            return View(aprintT);
        }

        // POST: AprintTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Affecter,Panne")] AprintT aprintT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aprintT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aprintT);
        }

        // GET: AprintTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AprintT aprintT = db.Affectation_Print_Teacher.Find(id);
            if (aprintT == null)
            {
                return HttpNotFound();
            }
            return View(aprintT);
        }

        // POST: AprintTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AprintT aprintT = db.Affectation_Print_Teacher.Find(id);
            db.Affectation_Print_Teacher.Remove(aprintT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
