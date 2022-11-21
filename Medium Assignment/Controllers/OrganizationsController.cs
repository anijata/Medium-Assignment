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
    [AuthorizeUser(Roles = "SuperAdmin")]
    public class OrganizationsController : Controller
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

        public WebApiClient apiClient {
            get {
                return _apiClient ?? new WebApiClient(AuthDetails.AccessToken);                      
            }

            set
            {
                _apiClient = value;
            }

        }

        public OrganizationsController()
        {
            
        }

        public void AddModelErrors(List<string> errors) {
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult Details(int id)
        {

            var model = new OrganizationDetailsViewModel
            {
                Id = id
            };

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {

            var model = new OrganizationNewViewModel();

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var model = new OrganizationEditViewModel {
                Id = id
            };
            

            return View(model);

        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }




        //public async Task<ActionResult> Delete(int id) {


        //    var result = await apiClient.Delete("organizations", id);

        //    return RedirectToAction("Index");
        //}


    }
}
