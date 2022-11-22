using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Models
{
    public class EmployeeListViewModel : WebAPIClientBindingModel
    {
        public List<EmployeeGetViewModel> Employees { get; set; }
    }
    public class EmployeeGetViewModel : WebAPIClientBindingModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DOJ { get; set; }

        public string Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Address field 2")]

        public string Address2 { get; set; }

        public string Country { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public string State { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }

        public string City { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public string EmployeeType { get; set; }

        [Required]
        public string Status { get; set; }

        public string ApplicationUserId { get; set; }

        public int OrganizationId { get; set; }

    }

    public class EmployeePostViewModel : WebAPIClientBindingModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
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

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DOJ { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Address field 2")]

        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public string EmployeeType { get; set; }

        [Required]
        public string Status { get; set; }

    }

    public class EmployeePutViewModel : WebAPIClientBindingModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
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

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DOJ { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Address field 2")]

        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public string EmployeeType { get; set; }

        [Required]
        public string Status { get; set; }

    }

    public class EmployeeDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
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

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DOJ { get; set; }

        public string Department { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }

        [Required]
        public string Status { get; set; }

    }

    public class EmployeeIndexViewModel 
    {
        public IEnumerable<EmployeeDetailsViewModel> Employees { get; set; }
    }

    public class EmployeeNewViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DOJ { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Address field 2")]

        public string Address2 { get; set; }

        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country from dropdown.")]
        public int CountryId { get; set; }


        [Display(Name = "State")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country from dropdown.")]
        public int StateId { get; set; }

        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country from dropdown.")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }

        [Required]
        public string Status { get; set; }

        public SelectList DepartmentsSelectList { get; set; }

    }

    public class EmployeeEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DOJ { get; set; }

        [Required]
        [Display(Name = "Department")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Department from dropdown.")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Address field 2")]

        public string Address2 { get; set; }

        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country from dropdown.")]
        public int CountryId { get; set; }


        [Display(Name = "State")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country from dropdown.")]
        public int StateId { get; set; }

        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country from dropdown.")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }

        [Required]
        public string Status { get; set; }

        public SelectList DepartmentsSelectList { get; set; }
    }

}