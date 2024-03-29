﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
namespace Medium_Assignment.Models
{
    public abstract class APIBindingModel
    {

        public bool IsSuccess { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
