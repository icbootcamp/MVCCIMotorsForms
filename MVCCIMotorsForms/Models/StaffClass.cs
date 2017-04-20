using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCCIMotorsForms.Models
{
    public class StaffClass
    {
        public int StaffId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }       
        [Display(Name = "Address1  ")]
        public string Address1 { get; set; }
        [Display(Name = "Salary")]
        public Nullable<decimal> Salary { get; set; }
        public bool isStaff { get; set; }
        [Display(Name = "Staff Position")]
        public int PersonTypeId { get; set; }
        public List<SelectListItem> StaffTypeList { get; set; }
    }

    public class StaffViewList 
    {
        public string ViewTitle { get; set; }
        public List<StaffClass> StaffList { get; set; }
    }
}