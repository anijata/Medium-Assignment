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
        [DataType(DataType.DateTime)]
        [Display(Name = "Review Cycle Start Date")]
        public DateTime ReviewCycleStartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
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
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employees")]
        public IEnumerable<int> EmployeeIds { get; set; }

        [Required]
        [Display(Name = "Reviewer")]
        public int? ReviewerId { get; set; }

        public MultiSelectList EmployeeSelectList { get; set; }

        public string[] SelectedEmployeeValues { get; set; }

        public SelectList ReviewerSelectList { get; set; }


    }

    public class EmployeeFeedback {
        [Required]
        public int EmployeeId {get; set;}
        [Required]
        [Display(Name = "Employee")]
        public string DisplayName { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        [Required]
        public string Feedback { get; set; }
    }
    public class ReviewSubmitReviewViewModel
    {

        [Required]
        [Display(Name = "Review Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Reviewer")]
        public string ReviewerDisplayName { get; set; }

        [Required]
        public IEnumerable<EmployeeFeedback> EmployeeFeedbacks { get; set; }

    }

}