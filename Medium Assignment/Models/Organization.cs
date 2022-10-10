using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Medium_Assignment.Custom_Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Medium_Assignment.Models
{
    public class Organization
    {
        [Key]
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

        public Country Country { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public State State { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }

        public City City { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int ApplicationUserId { get; set; }


    }
}