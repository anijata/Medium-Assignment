using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Medium_Assignment.Models;
using Medium_Assignment.Custom_Validation;
using System.ComponentModel.DataAnnotations;

namespace Medium_Assignment.Controllers
{

    public class TestGetViewModel
    {

        public int value1 { get; set; }

        public int value2 { get; set; }

    } 
    public class TestPostViewModel
    {

        public int value1 { get; set; }

        public int value2 { get; set; }

    }

    public class TestPutViewModel
    {

        public int value1 { get; set; }

        public int value2 { get; set; }

    }

    //[AuthorizeUser(Roles = "OrganizationAdmin, Employee")]
    public class TestController : Controller
    {

        public ActionResult New() {

            var model = new TestNewViewModel { value1 = 0, value2 = 0}; 

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Flush() {
            var requestCookies = Request.Cookies;
            var responseCookies = Response.Cookies;

            foreach (var key in Request.Cookies.AllKeys) {
                var cookie = Request.Cookies[key];
                cookie.Expires = DateTime.Now;
                cookie.Expires.AddDays(-1);
                responseCookies.Add(cookie);
            }

            return RedirectToAction("Index");
        }

        
    }
}