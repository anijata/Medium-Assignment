using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medium_Assignment.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Medium_Assignment.Custom_Validation;

namespace Medium_Assignment.Controllers
{
    [AuthorizeUser(Roles = "OrganizationAdmin")]
    public class DepartmentsController : Controller
    {
        public AuthDetails AuthDetails
        {
            get
            {
                if (HttpContext.Session["AuthDetails"] != null)
                    return (AuthDetails)HttpContext.Session["AuthDetails"];
                return new AuthDetails();
            }
            set { AuthDetails = value; }
        }

        private WebApiClient _apiClient;

        public WebApiClient apiClient
        {
            get
            {
                return _apiClient ?? new WebApiClient(AuthDetails.AccessToken);
            }

            set
            {
                _apiClient = value;
            }

        }

        public DepartmentsController() {
            

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new DepartmentNewViewModel();

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {

            var viewModel = new DepartmentEditViewModel {
                Id = id
            };

            return View(viewModel);


        }


        //public async Task<ActionResult> Delete(int id)
        //{

        //    var result = await apiClient.Delete("departments", id);

        //    if (!result)
        //    {
        //        // Add error
        //    }

        //    return RedirectToAction("Index");


        //}
    }
}