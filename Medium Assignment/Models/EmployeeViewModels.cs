using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Models
{
    public class EmployeeDetailsViewModel
    {
        public Employee Employee { get; set; }
    }

    public class EmployeeIndexViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }


    public class EmployeeNewViewModel
    {

        public Employee Employee { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public SelectList DepartmentsSelectList { get; set; }
        public SelectList StatesSelectList { get; set; }
        public SelectList CountriesSelectList { get; set; }
        public SelectList CitiesSelectList { get; set; }
    }

    public class EmployeeEditViewModel
    {

        public Employee Employee { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public SelectList DepartmentsSelectList { get; set; }
        public SelectList StatesSelectList { get; set; }
        public SelectList CountriesSelectList { get; set; }
        public SelectList CitiesSelectList { get; set; }
    }

}