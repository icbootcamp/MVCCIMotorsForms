using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCIMotorsForms.Models;

namespace MVCCIMotorsForms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StaffManagement( bool isStaff = true)
        {
            IC_MotersEntities db = new IC_MotersEntities();
            if (isStaff)
            {
                var staffList = db.People.Where(x => x.PersonTypeId != 4).Select(x => new StaffClass
                {
                    StaffId = x.PersonId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address1 = x.Address1
                }).ToList();
                StaffViewList staffViewList = new StaffViewList()
                {
                    StaffList = staffList,
                    ViewTitle = "Staff Management"
                };
                return View(staffViewList);
            }
            else
            {
                var staffList = db.People.Where(x => x.PersonTypeId == 4).Select(x => new StaffClass
                {
                    StaffId = x.PersonId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address1 = x.Address1
                }).ToList();
                StaffViewList staffViewList = new StaffViewList()
                {
                    StaffList = staffList,
                    ViewTitle = "Customer Management"
                };
                return View(staffViewList);
            }
            
        }

        public ActionResult EditStaffMember(int staffId)
        {
             IC_MotersEntities db = new IC_MotersEntities();

            var selectedStaff = db.People.Find(staffId);

            var staffToEdit = new StaffClass
            {
                FirstName = selectedStaff.FirstName,
                LastName = selectedStaff.LastName,
                StaffId = selectedStaff.PersonId,
                Address1 = selectedStaff.Address1,
                Salary = selectedStaff.Salary,
                PersonTypeId = selectedStaff.PersonTypeId
            };
              if ( selectedStaff.PersonTypeId == 4)
            {
                staffToEdit.isStaff = false;
            }     
              else
            {
                staffToEdit.isStaff = true;
                
                staffToEdit.StaffTypeList = db.PersonTypes.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.PersonTypeId.ToString()
                }).ToList();
            } 
            return View(staffToEdit);
        }

        [HttpPost]
        public ActionResult EditStaffMember(StaffClass staffData)
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var newStaff = db.People.Find(staffData.StaffId);
            
            newStaff.PersonId = staffData.StaffId;
            newStaff.FirstName = staffData.FirstName.Trim();
            newStaff.LastName = staffData.LastName.Trim();
            newStaff.Address1 = staffData.Address1.Trim();
            newStaff.Salary = staffData.Salary;
            newStaff.PersonTypeId = staffData.PersonTypeId;         
            db.SaveChanges();
            if ( staffData.isStaff)
            {
                return RedirectToAction("StaffManagement", "Home");
            }
            else
            {
                return RedirectToAction("StaffManagement", "Home", new { isStaff = false });
            }
        }
    }
}