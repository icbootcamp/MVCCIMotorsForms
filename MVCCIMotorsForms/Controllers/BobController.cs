using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCIMotorsForms.Models;

namespace MVCCIMotorsForms.Controllers
{
    public class BobController : Controller
    {
        // GET: Bob
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyView()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var personList = db.People.Select(x => new BobViewModel { FirstName = x.FirstName, LastName = x.LastName }).ToList();
            return View(personList);
        }
    }
}