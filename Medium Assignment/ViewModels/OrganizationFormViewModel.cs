using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medium_Assignment.Models;
using System.Web.Mvc;

namespace Medium_Assignment.ViewModels
{
    public class OrganizationFormViewModel
    {
        public Organization Organization { get; set; }
        public SelectList StatesSelectList { get; set; }
        public SelectList CountriesSelectList { get; set; }
        public SelectList CitiesSelectList { get; set; }
    }
}