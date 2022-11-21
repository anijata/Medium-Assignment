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


    [AuthorizeUser(Roles = "SuperAdmin")]
    public class TestController : Controller
    {
        public string AuthToken {
            get {
                if (HttpContext.Session["AuthToken"] != null)
                    return HttpContext.Session["AuthToken"].ToString();
                return "";
            }
            set {; }
        }

        public ActionResult New() {

            var model = new TestNewViewModel { value1 = 0, value2 = 0}; 

            return View(model);
        }

        public ActionResult Index()
        {
            // var client = new WebApiClient(AuthToken);

            //var result = await client.Get<TestGetViewModel>("test", 23);
            
            return View();
        }

        
    }
}