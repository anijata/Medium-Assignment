using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        public Designation Designation { get; set; }

        [Required]
        public int DesignationId { get; set; }

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DOJ { get; set; }

       
        public Department Department { get; set; }

        [Required]
        public int DepartmentId {get; set;} 

        [Required]
        public string Address { get; set; }

        
        
        public EmployeeType EmployeeType { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        public int EmployeeTypeId { get; set; }


        [Required]
        string Status { get; set; }




    }
}