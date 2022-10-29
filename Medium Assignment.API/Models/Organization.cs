namespace Medium_Assignment.API
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class OrganizationDTO {

        public OrganizationDTO() { 
        
        }

        public OrganizationDTO(Organization organization) {
            Id = organization.Id;
            Name = organization.Name;
            ApplicationUserId = organization.ApplicationUserId;
            CityId = organization.CityId;
            CountryId = organization.CountryId;
            Description = organization.Description;
            Email = organization.AspNetUser.Email;
            UserName = organization.AspNetUser.UserName;
            Address1 = organization.Address1;
            Address2 = organization.Address2;
            StateId = organization.StateId;
            Status = organization.Status;



        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }
        
        public string Address2 { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string ApplicationUserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }


    }

    public partial class Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {
            Departments = new HashSet<Department>();
            Employees = new HashSet<Employee>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual State State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
