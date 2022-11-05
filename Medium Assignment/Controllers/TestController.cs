using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Medium_Assignment.Models;

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
    

        public async Task<ActionResult> Index()
        {
            var client = new WebApiClient(AuthToken);

            var result = await client.Get<TestGetViewModel>("test", 23);
            
            return View();
        }
    }
}