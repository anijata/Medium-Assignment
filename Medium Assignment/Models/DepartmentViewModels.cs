﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Models
{
    public class DepartmentListViewModel : WebAPIClientBindingModel
    {
        public List<DepartmentGetViewModel> Departments { get; set; }
    }

    public class DepartmentGetViewModel : WebAPIClientBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }

    public class DepartmentPostViewModel : WebAPIClientBindingModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class DepartmentPutViewModel : WebAPIClientBindingModel
    {

        [Required]
        public string Name { get; set; }
    }

    public class DepartmentIndexViewModel
    {
        public IEnumerable<DepartmentGetViewModel> Departments;
    }

    public class DepartmentNewViewModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class DepartmentEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}