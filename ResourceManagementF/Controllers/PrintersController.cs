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
    public class PrintersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Printers
        public ActionResult Index()
        {
            return View(db.Impriments.Include("ProvidersId"));
        }

        // GET: Printers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Impriments.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // GET: Printers/Create
        public ActionResult Create()
        {
            ViewBag.prints = db.Fournisseurs;
            return View();
        }

        // POST: Printers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection,Printer printer)
        {
            try
            {
                // TODO: Add insert logic here
                int idDep = int.Parse(collection["Select1"]);
                foreach (var item in db.Fournisseurs)
                {
                    if (item.Id == idDep)
                        item.Printerslist.Add(printer);
                }

                db.Impriments.Add(printer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Printers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Impriments.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // POST: Printers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateLivraison,Warranty,Brand,Speed,Resolution")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(printer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(printer);
        }

        // GET: Printers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Impriments.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // POST: Printers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Printer printer = db.Impriments.Find(id);
            db.Impriments.Remove(printer);
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
