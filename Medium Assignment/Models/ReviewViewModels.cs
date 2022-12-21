using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Models
{

    public class ReviewListViewModel : APIBindingModel
    {

        public List<ReviewGetViewModel> Reviews;
    }
    public class ReviewGetViewModel : APIBindingModel
    {
        public int Id { get; set; }
        public string Reviewer { get; set; }
        public int? ReviewerId { get; set; }

        public string Employee { get; set; }

        public int? EmployeeId { get; set; }

        public int OrganizationId { get; set; }

        public string Agenda { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Review Cycle Start Date")]
        public DateTime ReviewCycleStartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Review Cycle End Date")]
        public DateTime ReviewCycleEndDate { get; set; }

        [Display(Name = "Min Rate")]
        public decimal MinRate { get; set; }

        [Display(Name = "Max Rate")]
        public decimal MaxRate { get; set; }

        public string Description { get; set; }
        public int? Rating { get; set; }
        public string Feedback { get; set; }

        public string ReviewStatus { get; set; }
        public int? ReviewStatusId { get; set; }
    }

    public class ReviewNewViewModel : APIBindingModel
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

    public class ReviewEditViewModel {

        [Required]
        public int Id { get; set; }

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
        public List<ReviewGetViewModel> Reviews;

    }
    public class ReviewAssignBindingModel : APIBindingModel
    {
        [Required]
        public int? ReviewerId { get; set; }

        [Required]

        public List<int?> EmployeeIds { get; set; }

    }

    public class ReviewSubmitBindingModel : APIBindingModel
    {
        [Required]
        public int Rating { get; set; }

        [Required]
        public string Feedback { get; set; }

    }

    public class ReviewAssignViewModel
    {

        [Required]
        [Display(Name = "Review Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employees")]
        [MinLength(1, ErrorMessage = "Select Employee from dropdown.")]
        public List<int?> EmployeeIds { get; set; }

        [Required]
        [Display(Name = "Reviewer")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Reviewer from dropdown.")]
        public int? ReviewerId { get; set; }

        public MultiSelectList EmployeeSelectList { get; set; }

        public string[] SelectedEmployeeValues { get; set; }

        public SelectList ReviewerSelectList { get; set; }


    }

    public class ReviewSubmitViewModel
    {

        [Required]
        [Display(Name = "Review Id")]
        public int Id { get; set; }


        [Display(Name = "Reviewer")]
        public string Reviewer { get; set; }

        [Display(Name = "Employee")]
        public string Employee { get; set; }

        [Required]
        public int Rating { get; set; }


        [Required]
        public string Feedback { get; set; }

    }

    public class ReviewDetailsViewModel : APIBindingModel
    {
        [Required]
        [Display(Name = "Review Id")]
        public int Id { get; set; }

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
        [Display(Name = "Employees")]
        [MinLength(1, ErrorMessage = "Select Employee from dropdown.")]
        public List<int?> EmployeeIds { get; set; }

        [Required]
        [Display(Name = "Reviewer")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Reviewer from dropdown.")]
        public int? ReviewerId { get; set; }

        [Required]
        public string Description { get; set; }
    }

}