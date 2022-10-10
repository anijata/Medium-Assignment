using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medium_Assignment.Models;

namespace Medium_Assignment.ViewModels
{
    public class IndexOrganizationViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
    }
}