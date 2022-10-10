using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Medium_Assignment.Models;

namespace Medium_Assignment.Custom_Validation
{
    public class UniqueName : ValidationAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var name = (string) value;

        //    var organization = (Organization) validationContext.ObjectInstance;

        //    int count = context.Organizations.Where(c => c.Name.Equals(name) && c.Id != organization.Id).Count();

        //    if (count == 0)
        //        return ValidationResult.Success;
        //    else {
        //        return new ValidationResult("Enter unique organization name.");
        //    }

        //}
    }
}