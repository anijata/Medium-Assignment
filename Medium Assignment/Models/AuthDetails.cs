using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medium_Assignment.Models
{
    public class AuthDetails
    {
        public bool IsAuthenticted { get; set; } = false;
        public string AccessToken { get; set; }
        public string TokenType { get; set; }

        public TimeSpan ExpiresIn { get; set; }
        public string UserName { get; set; }

        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }
        public List<string> Roles { get; set; }


        public bool IsInRole(string Role)
        {
            return Roles.Contains(Role);
        }
    }
}