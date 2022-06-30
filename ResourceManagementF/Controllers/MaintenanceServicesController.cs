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
    public class MaintenanceServicesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: MaintenanceServices
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        // GET: MaintenanceServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceService maintenanceService = db.Services.Find(id);
            if (maintenanceService == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceService);
        }

        // GET: MaintenanceServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Services")] MaintenanceService maintenanceService)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(maintenanceService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maintenanceService);
        }

        // GET: MaintenanceServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceService maintenanceService = db.Services.Find(id);
            if (maintenanceService == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceService);
        }

        // POST: MaintenanceServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Services")] MaintenanceService maintenanceService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintenanceService);
        }

        // GET: MaintenanceServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceService maintenanceService = db.Services.Find(id);
            if (maintenanceService == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceService);
        }

        // POST: MaintenanceServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceService maintenanceService = db.Services.Find(id);
            db.Services.Remove(maintenanceService);
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
