using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication2.Controllers
{
    public class MEMBERSHIPsController : Controller
    {
        private Entities6 db = new Entities6();

        // GET: MEMBERSHIPs
        public ActionResult Index()
        {
			ExecuteUpdateMembershipStatusFunction();

			var memberships = db.MEMBERSHIPS.ToList();
			return View(memberships);
		}
		private void ExecuteUpdateMembershipStatusFunction()
		{
			string connectionString = "DATA SOURCE=localhost:1521/XEPDB1;TNS_ADMIN=C:\\Users\\ASUS\\Oracle\\network\\admin;PERSIST SECURITY INFO=True;USER ID=SARUNAASUS ; PASSWORD=Asus2001;";

			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				connection.Open();

				using (OracleCommand additionalCommand = new OracleCommand(
					"DECLARE " +
					"    result NUMBER; " +
					"BEGIN " +
					"    result := UpdateMembershipStatus; " +
					"END;", connection))
				{
					additionalCommand.ExecuteNonQuery(); // Execute the code block
				}
			}
		}


		// GET: MEMBERSHIPs/Details/5
		public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERSHIP mEMBERSHIP = db.MEMBERSHIPS.Find(id);
            if (mEMBERSHIP == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERSHIP);
        }

        // GET: MEMBERSHIPs/Create
        public ActionResult Create()
        {
            return View();
        }
		

		// POST: MEMBERSHIPs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MEMBERSHIP_NO,MEMBERSHIP_TYPE,MEM_PERIOD,STATUS,PAY_DATE,PRICE")] MEMBERSHIP mEMBERSHIP)
        {
            if (ModelState.IsValid)
            {
                db.MEMBERSHIPS.Add(mEMBERSHIP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mEMBERSHIP);
        }

        // GET: MEMBERSHIPs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERSHIP mEMBERSHIP = db.MEMBERSHIPS.Find(id);
            if (mEMBERSHIP == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERSHIP);
        }

        // POST: MEMBERSHIPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEMBERSHIP_NO,MEMBERSHIP_TYPE,MEM_PERIOD,STATUS,PAY_DATE,PRICE")] MEMBERSHIP mEMBERSHIP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBERSHIP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEMBERSHIP);
        }

        // GET: MEMBERSHIPs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERSHIP mEMBERSHIP = db.MEMBERSHIPS.Find(id);
            if (mEMBERSHIP == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERSHIP);
        }

        // POST: MEMBERSHIPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MEMBERSHIP mEMBERSHIP = db.MEMBERSHIPS.Find(id);
            db.MEMBERSHIPS.Remove(mEMBERSHIP);
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
