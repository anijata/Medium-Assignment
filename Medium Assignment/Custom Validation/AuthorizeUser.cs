﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medium_Assignment.Models;
using System.Web.Mvc;
using System.Net;
using System.Web.Routing;

namespace Medium_Assignment.Custom_Validation
{
    [AttributeUsage(AttributeTargets.Class)]

    public class AuthorizeUser : AuthorizeAttribute, IAuthorizationFilter
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext) {

            if (httpContext.Session["AuthDetails"] == null) {
                return false;
            }

            AuthDetails authDetails = (AuthDetails)httpContext.Session["AuthDetails"];

            return authDetails.Roles.Contains(Roles);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            filterContext.Result = new RedirectToRouteResult(
           new RouteValueDictionary{{ "controller", "Home" },
                                          { "action", "NotAuthorized" }});
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

        }
    }
}