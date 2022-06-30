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
    public class AcompDepsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AcompDeps
        public ActionResult Index()
        {
            return View(db.Affectation_Comp_Dep.Include("Deps").Include("Comp"));
        }

        // GET: AcompDeps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcompDep acompDep = db.Affectation_Comp_Dep.Find(id);
            if (acompDep == null)
            {
                return HttpNotFound();
            }
            return View(acompDep);
        }

        // GET: AcompDeps/Create
        public ActionResult Create()
        {
            ViewBag.depts = db.Departements;
            ViewBag.comps = db.Ordinateurs;
            return View();
        }

        // POST: AcompDeps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, AcompDep acompDep)
        {
            try
            {
                // TODO: Add insert logic here
                int idDep = int.Parse(collection["Select1"]);
                int idCom = int.Parse(collection["Select2"]);
                foreach (var item in db.Departements)
                {
                    if (item.Id == idDep)
                        item.AcompDepList.Add(acompDep);
                }
                foreach (var item in db.Ordinateurs)
                {
                    if (item.Id == idCom)
                        item.ACompDepList.Add(acompDep);
                }
                db.Affectation_Comp_Dep.Add(acompDep);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AcompDeps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcompDep acompDep = db.Affectation_Comp_Dep.Find(id);
            if (acompDep == null)
            {
                return HttpNotFound();
            }
            return View(acompDep);
        }

        // POST: AcompDeps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Affecter,Panne")] AcompDep acompDep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acompDep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acompDep);
        }

        // GET: AcompDeps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcompDep acompDep = db.Affectation_Comp_Dep.Find(id);
            if (acompDep == null)
            {
                return HttpNotFound();
            }
            return View(acompDep);
        }

        // POST: AcompDeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcompDep acompDep = db.Affectation_Comp_Dep.Find(id);
            db.Affectation_Comp_Dep.Remove(acompDep);
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
