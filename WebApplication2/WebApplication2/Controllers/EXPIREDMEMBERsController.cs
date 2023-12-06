using Oracle.ManagedDataAccess.Client;
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
    public class EXPIREDMEMBERsController : Controller
    {
        private Entities7 db = new Entities7();

        // GET: EXPIREDMEMBERs
        public ActionResult Index()
        {
            ExecuteExpiredMembershipFunction();
            var eXPIREDMEMBER=db.EXPIREDMEMBERS.ToList();

			return View(eXPIREDMEMBER);
        }
        private void ExecuteExpiredMembershipFunction()
        {
			string connectionString = "DATA SOURCE=localhost:1521/XEPDB1;TNS_ADMIN=C:\\Users\\ASUS\\Oracle\\network\\admin;PERSIST SECURITY INFO=True;USER ID=SARUNAASUS ; PASSWORD=Asus2001;";

			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				connection.Open();

				using (OracleCommand additionalCommand1 = new OracleCommand(
					"DECLARE " +
					"    result NUMBER; " +
					"BEGIN " +
					"    result := UpdateMembershipStatusAndMoveExpired; " +
					"END;", connection))
				{
					additionalCommand1.ExecuteNonQuery(); // Execute the code block
				}
			}
		}
	/*	// GET: EXPIREDMEMBERs/Details/5
		public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXPIREDMEMBER eXPIREDMEMBER = db.EXPIREDMEMBERS.Find(id);
            if (eXPIREDMEMBER == null)
            {
                return HttpNotFound();
            }
            return View(eXPIREDMEMBER);
        }

        // GET: EXPIREDMEMBERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EXPIREDMEMBERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MEMBERSHIP_NO,MEM_STATUS,EXPIRED_DATE")] EXPIREDMEMBER eXPIREDMEMBER)
        {
            if (ModelState.IsValid)
            {
                db.EXPIREDMEMBERS.Add(eXPIREDMEMBER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eXPIREDMEMBER);
        }

        // GET: EXPIREDMEMBERs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXPIREDMEMBER eXPIREDMEMBER = db.EXPIREDMEMBERS.Find(id);
            if (eXPIREDMEMBER == null)
            {
                return HttpNotFound();
            }
            return View(eXPIREDMEMBER);
        }

        // POST: EXPIREDMEMBERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEMBERSHIP_NO,MEM_STATUS,EXPIRED_DATE")] EXPIREDMEMBER eXPIREDMEMBER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eXPIREDMEMBER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eXPIREDMEMBER);
        }
    */
        // GET: EXPIREDMEMBERs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXPIREDMEMBER eXPIREDMEMBER = db.EXPIREDMEMBERS.Find(id);
            if (eXPIREDMEMBER == null)
            {
                return HttpNotFound();
            }
            return View(eXPIREDMEMBER);
        }

        // POST: EXPIREDMEMBERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            EXPIREDMEMBER eXPIREDMEMBER = db.EXPIREDMEMBERS.Find(id);
            db.EXPIREDMEMBERS.Remove(eXPIREDMEMBER);
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
