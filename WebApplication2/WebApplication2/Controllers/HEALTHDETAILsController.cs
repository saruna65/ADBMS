using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HEALTHDETAILsController : Controller
    {
        private Entities5 db = new Entities5();

        // GET: HEALTHDETAILs
        public ActionResult Index()
        {
            return View(db.HEALTHDETAILS.ToList());
        }

   /*     // GET: HEALTHDETAILs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HEALTHDETAIL hEALTHDETAIL = db.HEALTHDETAILS.Find(id);
            if (hEALTHDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(hEALTHDETAIL);
        }
   */
        // GET: HEALTHDETAILs/Create
        public ActionResult Create()
        {
            return View();
        }

		// POST: HEALTHDETAILs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "MEMBERSHIP_NO,DISABILITIES,HEIGHT,WEIGHT,BMI,BMI_CAT")] HEALTHDETAIL hEALTHDETAIL)
		{
			if (ModelState.IsValid)
			{
				db.HEALTHDETAILS.Add(hEALTHDETAIL);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(hEALTHDETAIL);
		}

		// GET: HEALTHDETAILs/Edit/5
		public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HEALTHDETAIL hEALTHDETAIL = db.HEALTHDETAILS.Find(id);
            if (hEALTHDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(hEALTHDETAIL);
        }

        // POST: HEALTHDETAILs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEMBERSHIP_NO,DISABILITIES,HEIGHT,WEIGHT,BMI,BMI_CAT")] HEALTHDETAIL hEALTHDETAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hEALTHDETAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hEALTHDETAIL);
        }

        // GET: HEALTHDETAILs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HEALTHDETAIL hEALTHDETAIL = db.HEALTHDETAILS.Find(id);
            if (hEALTHDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(hEALTHDETAIL);
        }

        // POST: HEALTHDETAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            HEALTHDETAIL hEALTHDETAIL = db.HEALTHDETAILS.Find(id);
            db.HEALTHDETAILS.Remove(hEALTHDETAIL);
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
