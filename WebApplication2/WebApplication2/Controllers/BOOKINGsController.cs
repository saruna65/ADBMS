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
    public class BOOKINGsController : Controller
    {
        private Entities8 db = new Entities8();

        // GET: BOOKINGs
        public ActionResult Index()
        {
            return View(db.BOOKINGS.ToList());
        }

        // GET: BOOKINGs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKING bOOKING = db.BOOKINGS.Find(id);
            if (bOOKING == null)
            {
                return HttpNotFound();
            }
            return View(bOOKING);
        }

        // GET: BOOKINGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BOOKINGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MEM_NO,TIME_SLOT")] BOOKING bOOKING)
		{
			if (ModelState.IsValid)
			{
				// Call the book_slot procedure to perform additional checks and insert data
				CallBookSlotProcedure(bOOKING.MEM_NO , bOOKING.TIME_SLOT);

				
				return RedirectToAction("Index");
			}

			return View(bOOKING);
		}
		private void CallBookSlotProcedure(decimal? memNo, string timeSlot)
		{
			using (var conn = new OracleConnection("DATA SOURCE=localhost:1521/XEPDB1;TNS_ADMIN=C:\\Users\\ASUS\\Oracle\\network\\admin;PERSIST SECURITY INFO=True;USER ID=SARUNAASUS; PASSWORD=Asus2001;"))
			using (var cmd = new OracleCommand("BOOK_SLOT", conn))
			{
				try
				{
					cmd.CommandType = CommandType.StoredProcedure;

					// Check if MEM_NO is null and set it to DBNull if it is
					if (memNo.HasValue)
					{
						cmd.Parameters.Add("P_mem_no", OracleDbType.Decimal).Value = memNo.Value;
					}
					else
					{
						cmd.Parameters.Add("P_mem_no", OracleDbType.Decimal).Value = DBNull.Value;
					}

					cmd.Parameters.Add("p_time_slot", OracleDbType.Varchar2).Value = timeSlot;

					conn.Open();
					cmd.ExecuteNonQuery();
				}
				catch (OracleException ex)
				{
					// Handle Oracle database-related exceptions
					ModelState.AddModelError(string.Empty, "Database error: " + ex.Message);
				}
				catch (Exception ex)
				{
					// Handle other general exceptions
					ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
				}
			}
		}



		// GET: BOOKINGs/Edit/5
		public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKING bOOKING = db.BOOKINGS.Find(id);
            if (bOOKING == null)
            {
                return HttpNotFound();
            }
            return View(bOOKING);
        }

        // POST: BOOKINGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOKING_ID,MEM_NO,F_NAME,BOOK_DATE,TIME_SLOT")] BOOKING bOOKING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOKING).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOOKING);
        }

        // GET: BOOKINGs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKING bOOKING = db.BOOKINGS.Find(id);
            if (bOOKING == null)
            {
                return HttpNotFound();
            }
            return View(bOOKING);
        }

        // POST: BOOKINGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            BOOKING bOOKING = db.BOOKINGS.Find(id);
            db.BOOKINGS.Remove(bOOKING);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		public ActionResult DeleteAll()
		{
			// Retrieve all bookings from the database
			var bookings = db.BOOKINGS.ToList();

			// Remove all bookings from the database
			foreach (var booking in bookings)
			{
				db.BOOKINGS.Remove(booking);
			}

			// Save the changes to the database
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
