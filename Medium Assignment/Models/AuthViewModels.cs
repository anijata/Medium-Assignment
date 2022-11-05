﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medium_Assignment.Models
{
    public class AuthTokenBindingModel
    {

        public string grant_type { get; set; }
        public string username { get; set; }

        public string password { get; set; }

    }

    public class AuthTokenViewModel
    {

        public string AccessToken { get; set; }
        public string TokenType { get; set; }

        public TimeSpan ExpiresIn { get; set; }
        public string UserName { get; set; }

        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }

    }
    
}