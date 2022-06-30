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
    public class AprintDepsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AprintDeps
        public ActionResult Index()
        {
            return View(db.Affectation_Print_Dep.Include("Deps").Include("Prints"));
        }

        // GET: AprintDeps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AprintDep aprintDep = db.Affectation_Print_Dep.Find(id);
            if (aprintDep == null)
            {
                return HttpNotFound();
            }
            return View(aprintDep);
        }

        // GET: AprintDeps/Create
        public ActionResult Create()
        {
            ViewBag.depts = db.Departements;
            ViewBag.prints = db.Impriments;
            return View();
        }

        // POST: AprintDeps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, AprintDep aprintDep)
        {
            try
            {
                // TODO: Add insert logic here
                int idDep = int.Parse(collection["Select1"]);
                int idPrin = int.Parse(collection["Select2"]);
                foreach (var item in db.Departements)
                {
                    if (item.Id == idDep)
                        item.AprintDepList.Add(aprintDep);
                }
                foreach (var item in db.Impriments)
                {
                    if (item.Id == idPrin)
                        item.APrintList.Add(aprintDep);
                }
                db.Affectation_Print_Dep.Add(aprintDep);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AprintDeps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AprintDep aprintDep = db.Affectation_Print_Dep.Find(id);
            if (aprintDep == null)
            {
                return HttpNotFound();
            }
            return View(aprintDep);
        }

        // POST: AprintDeps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Affecter,Panne")] AprintDep aprintDep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aprintDep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aprintDep);
        }

        // GET: AprintDeps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AprintDep aprintDep = db.Affectation_Print_Dep.Find(id);
            if (aprintDep == null)
            {
                return HttpNotFound();
            }
            return View(aprintDep);
        }

        // POST: AprintDeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AprintDep aprintDep = db.Affectation_Print_Dep.Find(id);
            db.Affectation_Print_Dep.Remove(aprintDep);
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
