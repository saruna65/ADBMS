using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MEMBERCREDsController : Controller
    {
        private Entities10 db = new Entities10();

        // GET: MEMBERCREDs
        public ActionResult Index()
        {
            return View(db.MEMBERCREDs.ToList());
        }

        // GET: MEMBERCREDs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERCRED mEMBERCRED = db.MEMBERCREDs.Find(id);
            if (mEMBERCRED == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERCRED);
        }

        // GET: MEMBERCREDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MEMBERCREDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MEMBERSHIP_NO,PASSSWORD")] MEMBERCRED mEMBERCRED)
        {
            if (ModelState.IsValid)
            {
                db.MEMBERCREDs.Add(mEMBERCRED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mEMBERCRED);
        }

        // GET: MEMBERCREDs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERCRED mEMBERCRED = db.MEMBERCREDs.Find(id);
            if (mEMBERCRED == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERCRED);
        }

        // POST: MEMBERCREDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEMBERSHIP_NO,PASSSWORD")] MEMBERCRED mEMBERCRED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBERCRED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEMBERCRED);
        }

        // GET: MEMBERCREDs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERCRED mEMBERCRED = db.MEMBERCREDs.Find(id);
            if (mEMBERCRED == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERCRED);
        }

        // POST: MEMBERCREDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MEMBERCRED mEMBERCRED = db.MEMBERCREDs.Find(id);
            db.MEMBERCREDs.Remove(mEMBERCRED);
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
