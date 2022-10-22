﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Medium_Assignment.Custom_Validation;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medium_Assignment.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string Agenda { get; set; }

        [Display(Name = "Review Cycle Start Date")]
        public DateTime ReviewCycleStartDate { get; set; }

        [Display(Name = "Review Cycle End Date")]
        public DateTime ReviewCycleEndDate { get; set; }

        [Display(Name = "Min Rate")]
        public decimal MinRate { get; set; }

        [Display(Name = "Max Rate")]
        public decimal MaxRate { get; set; }

        public string Description { get; set; }

        [ForeignKey("ReviewerId")]
        public Employee Reviewer { get; set; }

        public int? ReviewerId { get; set; }

        public int Rating { get; set; }

        public string Feedback { get; set; }

        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }

        public int OrganizationId { get; set; }

        
        [ForeignKey("ReviewStatusId")] 
        public ReviewStatus ReviewStatus { get; set; }

        public int ReviewStatusId { get; set; }
    }
}