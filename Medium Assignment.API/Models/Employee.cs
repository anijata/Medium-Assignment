namespace Medium_Assignment.API
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Reviews = new HashSet<Review>();
            Reviews1 = new HashSet<Review>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Designation { get; set; }

        public DateTime DOJ { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        public string Address1 { get; set; }

        [Required]
        public string Address2 { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public string EmployeeType { get; set; }

        [Required]
        public string Status { get; set; }

        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public int OrganizationId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Department Department { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual State State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews1 { get; set; }
    }
}
