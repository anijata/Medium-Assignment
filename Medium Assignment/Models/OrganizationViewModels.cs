﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Medium_Assignment.Models
{
    public class OrganizationGetViewModel : APIBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

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

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address field 2")]
        public string Address2 { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }

    public class OrganizationPostViewModel : APIBindingModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

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

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address field 2")]
        public string Address2 { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }


    }

    public class OrganizationListViewModel : APIBindingModel
    {
        public List<OrganizationGetViewModel> Organizations { get; set; }
    }

    public class OrganizationDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

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

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

    }

    public class OrganizationIndexViewModel
    {
        public IEnumerable<OrganizationGetViewModel> Organizations { get; set; }
    }

    public class OrganizationNewViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
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
        public string Status { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

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

    }

    public class OrganizationEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address field 2")]
        public string Address2 { get; set; }

        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country from dropdown.")]
        public int CountryId { get; set; }


        [Display(Name = "State")]
        [Range(1, int.MaxValue, ErrorMessage = "Select State from dropdown.")]
        public int StateId { get; set; }

        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "Select City from dropdown.")]
        public int CityId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

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
    }

    public class OrganizationPutViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

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

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address field 1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address field 2")]
        public string Address2 { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }

    public class OrganizationDeleteViewModel : APIBindingModel
    {
    }
}