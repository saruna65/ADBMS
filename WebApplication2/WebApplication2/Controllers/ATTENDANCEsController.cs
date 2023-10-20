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
    public class ATTENDANCEsController : Controller
    {
        private Entities9 db = new Entities9();

        // GET: ATTENDANCEs
        public ActionResult Index()
        {
            return View(db.ATTENDANCEs.ToList());
        }

        // GET: ATTENDANCEs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATTENDANCE aTTENDANCE = db.ATTENDANCEs.Find(id);
            if (aTTENDANCE == null)
            {
                return HttpNotFound();
            }
            return View(aTTENDANCE);
        }

        // GET: ATTENDANCEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ATTENDANCEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MEMBER_NO")] ATTENDANCE aTTENDANCE)
        {
            if (ModelState.IsValid)
            {
                db.ATTENDANCEs.Add(aTTENDANCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aTTENDANCE);
        }

        // GET: ATTENDANCEs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATTENDANCE aTTENDANCE = db.ATTENDANCEs.Find(id);
            if (aTTENDANCE == null)
            {
                return HttpNotFound();
            }
            return View(aTTENDANCE);
        }

        // POST: ATTENDANCEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEMBER_NO,ATTENDANCE_DATE,STATUS,ATT_TIME")] ATTENDANCE aTTENDANCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTTENDANCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aTTENDANCE);
        }

        // GET: ATTENDANCEs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATTENDANCE aTTENDANCE = db.ATTENDANCEs.Find(id);
            if (aTTENDANCE == null)
            {
                return HttpNotFound();
            }
            return View(aTTENDANCE);
        }

        // POST: ATTENDANCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ATTENDANCE aTTENDANCE = db.ATTENDANCEs.Find(id);
            db.ATTENDANCEs.Remove(aTTENDANCE);
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
