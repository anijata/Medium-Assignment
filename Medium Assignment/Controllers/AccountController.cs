using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Medium_Assignment.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Medium_Assignment.Controllers
{
    public class AccountController : Controller
    {
        public string AuthToken
        {
            get
            {
                if (HttpContext.Session["AuthToken"] != null)
                    return HttpContext.Session["AuthToken"].ToString();
                return "";
            }
            set { AuthToken = value; }
        }
        public bool IsAuthenticated
        {
            get
            {
                if (HttpContext.Session["IsAuthenticated"] != null)
                    return (bool) HttpContext.Session["IsAuthenticated"];

                return false;
            }
            set { IsAuthenticated = value; }
        }
        public string UserName
        {
            get
            {
                if (HttpContext.Session["UserName"] != null)
                    return HttpContext.Session["UserName"].ToString();
                return "";
            }
            set { UserName = value; }
        }

        public AccountController()
        {
        }

        //
        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = new WebApiClient();

            var authTokenModel = new AuthTokenBindingModel { 
                grant_type = "password",
                username = model.UserName,
                password = model.Password
            };

            var result1 = await client.Authenticate(authTokenModel);

            if (!result1.IsSuccess) {
                foreach (var error in result1.Errors) {
                    ModelState.AddModelError("", error); 
                }

                return View(model);
            }

            client.AuthToken = result1.AccessToken;

            var result2 = await client.Get<AuthRolesViewModel>("account/roles");

            if (!result2.IsSuccess)
            {
                foreach (var error in result2.Errors)
                {
                    ModelState.AddModelError("", error);
                }

                return View(model);
            }

            var token = result1.AccessToken;

            var authDetails = new AuthDetails {
                IsAuthenticted = true,
                UserName = result1.UserName,
                AccessToken = result1.AccessToken,
                Expires = result1.Expires,
                ExpiresIn = result1.ExpiresIn,               
                Issued = result1.Issued,
                Roles = result2.Roles,
                TokenType = result1.TokenType,
            };

            HttpContext.Session["AuthDetails"] = authDetails;

            //HttpContext.Session["AuthToken"] = token;
            //HttpContext.Session["IsAuthenticated"] = true;
            //HttpContext.Session["UserName"] = model.UserName;

            return RedirectToLocal(returnUrl);

            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //}
        }

        //
        // GET: /Account/LoginOff
        public ActionResult LogOff(string returnUrl)
        {
            if (HttpContext.Session["AuthDetails"] != null)
                HttpContext.Session.Remove("AuthDetails");
            return RedirectToAction("Index", "Home");
        }



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}