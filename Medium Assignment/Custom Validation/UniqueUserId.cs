using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Medium_Assignment.Models;

namespace Medium_Assignment.Custom_Validation
{
    public class UniqueUserId: ValidationAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var userid = (string)value;

        //    var organization = (Organization)validationContext.ObjectInstance;

        //    int count = context.Organizations.Where(c => c.UserId.Equals(userid) && c.Id != organization.Id).Count();

        //    if (count == 0)
        //        return ValidationResult.Success;
        //    else
        //    {
        //        return new ValidationResult("Enter unique user Id.");
        //    }

        //}
    }
}