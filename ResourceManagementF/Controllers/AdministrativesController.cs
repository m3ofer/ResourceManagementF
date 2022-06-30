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
    public class AdministrativesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Administratives
        public ActionResult Index()
        {
            return View(db.Administratifs.ToList());
        }

        // GET: Administratives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrative administrative = db.Administratifs.Find(id);
            if (administrative == null)
            {
                return HttpNotFound();
            }
            return View(administrative);
        }

        // GET: Administratives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administratives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Isresp")] Administrative administrative)
        {
            if (ModelState.IsValid)
            {
                db.Administratifs.Add(administrative);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrative);
        }

        // GET: Administratives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrative administrative = db.Administratifs.Find(id);
            if (administrative == null)
            {
                return HttpNotFound();
            }
            return View(administrative);
        }

        // POST: Administratives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Isresp")] Administrative administrative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrative);
        }

        // GET: Administratives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrative administrative = db.Administratifs.Find(id);
            if (administrative == null)
            {
                return HttpNotFound();
            }
            return View(administrative);
        }

        // POST: Administratives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrative administrative = db.Administratifs.Find(id);
            db.Administratifs.Remove(administrative);
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
