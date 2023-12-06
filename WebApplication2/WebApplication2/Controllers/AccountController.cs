using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly Entities13 db = new Entities13();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ADMIN model)
        {
			if (ModelState.IsValid)
			{
				var user = db.ADMINs.FirstOrDefault(u => u.NAME == model.NAME && u.PASSWORD == model.PASSWORD);

				if (user != null)
				{
					
					return RedirectToAction("Index","MEMBERs");
				}
				else
				{
					ModelState.AddModelError("", "Invalid username or password");
					return View(model);
				}
			}

			return View(model);
		}

	}
}
