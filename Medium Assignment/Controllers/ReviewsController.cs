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
    public class ReviewsController : Controller
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

        public ReviewsController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeUser(Roles = "Employee")]
        [Route("reviews/assigned")]
        public ActionResult AssignedReviews()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new ReviewNewViewModel();

            return View(viewModel);

        }

        public ActionResult Assign(int id)
        {
            var viewModel = new ReviewAssignViewModel
            {

                Id = id

            };

            return View(viewModel);

        }

        [AuthorizeUser(Roles = "Employee")]
        public ActionResult Submit(int id)
        {
            var viewModel = new ReviewSubmitViewModel
            {
                Id = id
            };


            return View(viewModel);
        }


        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}




        //public async Task<ActionResult> Delete(int Id)
        //{
        //    //var organization = Context.Organizations.SingleOrDefault(c => c.Id == Id);

        //    //if (organization == null)
        //    //    return HttpNotFound();

        //    //var user = await UserManager.FindByIdAsync(organization.ApplicationUserId);

        //    //var result = await UserManager.DeleteAsync(user);

        //    //if (!result.Succeeded)
        //    //{
        //    //    return HttpNotFound();
        //    //}

        //    //Context.Organizations.Remove(organization);

        //    //Context.SaveChanges();

        //    //return RedirectToAction("Index");

        //    return View();


        //}



    }
}