using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Models
{
    public class TestNewViewModel
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        public int value1 { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        public int value2 { get; set; }
    }

    public class TestEditViewModel
    {
        public int value1 { get; set; }

        public int value2 { get; set; }
    }


    public class TestIndexViewModel
    {
        public int value1 { get; set; }

        public int value2 { get; set; }
    }
}