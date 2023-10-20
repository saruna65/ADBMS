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
    public class MEMBERsController : Controller
    {
        private Entities4 db = new Entities4();

        // GET: MEMBERs
        public ActionResult Index()
        {
            return View(db.MEMBERS.ToList());
        }

        // GET: MEMBERs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBERS.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Create
        public ActionResult Create()
        {
            return View();
        }

		// POST: MEMBERs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "FULL_NAME, GENDER, ADDRESS, MOBILE_NO, DOB, EMER_CONT_PERS, EMER_CONT_PERS_NO, SYS_PASSWORD")] MEMBER mEMBER)
		{
			if (ModelState.IsValid)
			{
				// Call the registration procedure from Oracle and pass member data
				using (Entities4 db = new Entities4())
				{
					db.Database.ExecuteSqlCommand("BEGIN register_member(:p_full_name, :p_gender, :p_address, :p_mobile_no, :p_dob, :p_emer_cont_pers, :p_emer_cont_pers_no, :p_sys_password); END;",
						new OracleParameter("p_full_name", mEMBER.FULL_NAME),
						new OracleParameter("p_gender", mEMBER.GENDER),
						new OracleParameter("p_address", mEMBER.ADDRESS),
						new OracleParameter("p_mobile_no", mEMBER.MOBILE_NO),
						new OracleParameter("p_dob", mEMBER.DOB),
						new OracleParameter("p_emer_cont_pers", mEMBER.EMER_CONT_PERS),
						new OracleParameter("p_emer_cont_pers_no", mEMBER.EMER_CONT_PERS_NO),
						new OracleParameter("p_sys_password", mEMBER.SYS_PASSWORD)
					);

					return RedirectToAction("Index");
				}
			}

			return View(mEMBER);
		}


		// GET: MEMBERs/Edit/5
		public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBERS.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEMBERSHIP_NO,FULL_NAME,GENDER,ADDRESS,MOBILE_NO,DOB,EMER_CONT_PERS,EMER_CONT_PERS_NO,SYS_PASSWORD")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = db.MEMBERS.Find(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MEMBER mEMBER = db.MEMBERS.Find(id);
            db.MEMBERS.Remove(mEMBER);
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
