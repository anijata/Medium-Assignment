using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Models
{
    public class ReviewCreateViewModel
    {
        [Required]
        public string Agenda { get; set; }

        [Required]
        [Display(Name = "Review Cycle Start Date")]
        public DateTime ReviewCycleStartDate { get; set; }

        [Required]
        [Display(Name = "Review Cycle End Date")]
        public DateTime ReviewCycleEndDate { get; set; }

        [Required]
        [Display(Name = "Min Rate")]
        public decimal MinRate { get; set; }

        [Required]
        [Display(Name = "Max Rate")]
        public decimal MaxRate { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class ReviewIndexViewModel {
        public IEnumerable<Review> Reviews;
    
    }

    public class ReviewAssignReviewViewModel
    {
        
        [Required]
        [Display(Name = "Review Id")]
        public int Id { get; set;}

        [Required]
        [Display(Name="Employees")]
        public IEnumerable<int?> EmployeeIds { get; set; }
        
        [Required]
        [Display(Name = "Reviewer")]
        public int? ReviewerId { get; set; }

        public SelectList EmployeeSelectList { get; set; }

        public SelectList ReviewerSelectList { get; set; }


    }
}