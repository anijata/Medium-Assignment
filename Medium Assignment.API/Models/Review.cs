namespace Medium_Assignment.API
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        public int Id { get; set; }

        public string Agenda { get; set; }

        public DateTime ReviewCycleStartDate { get; set; }

        public DateTime ReviewCycleEndDate { get; set; }

        public decimal MinRate { get; set; }

        public decimal MaxRate { get; set; }

        public string Description { get; set; }

        public int? ReviewerId { get; set; }

        public int OrganizationId { get; set; }

        public int ReviewStatusId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public int Rating { get; set; }

        public string Feedback { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ReviewStatus ReviewStatus { get; set; }
    }
}
