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
    public class AcompTsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AcompTs
        public ActionResult Index()
        {
            return View(db.Affectation_Comp_Teacher.Include("Profs").Include("Computers"));
        }

        // GET: AcompTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcompT acompT = db.Affectation_Comp_Teacher.Find(id);
            if (acompT == null)
            {
                return HttpNotFound();
            }
            return View(acompT);
        }

        // GET: AcompTs/Create
        public ActionResult Create()
        {
            ViewBag.depts = db.Enseignants;
            ViewBag.comps = db.Ordinateurs;
            return View();
        }

        // POST: AcompTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, AcompT acompT)
        {
            try
            {
                // TODO: Add insert logic here
                int idDep = int.Parse(collection["Select1"]);
                int idCom = int.Parse(collection["Select2"]);
                foreach (var item in db.Enseignants)
                {
                    if (item.Id == idDep)
                        item.AcompTeachersLists.Add(acompT);
                }
                foreach (var item in db.Ordinateurs)
                {
                    if (item.Id == idCom)
                        item.ACompTList.Add(acompT);
                }
                db.Affectation_Comp_Teacher.Add(acompT);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AcompTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcompT acompT = db.Affectation_Comp_Teacher.Find(id);
            if (acompT == null)
            {
                return HttpNotFound();
            }
            return View(acompT);
        }

        // POST: AcompTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Affecter,Panne")] AcompT acompT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acompT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acompT);
        }

        // GET: AcompTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcompT acompT = db.Affectation_Comp_Teacher.Find(id);
            if (acompT == null)
            {
                return HttpNotFound();
            }
            return View(acompT);
        }

        // POST: AcompTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcompT acompT = db.Affectation_Comp_Teacher.Find(id);
            db.Affectation_Comp_Teacher.Remove(acompT);
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
