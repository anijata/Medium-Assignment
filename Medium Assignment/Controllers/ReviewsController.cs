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

namespace Medium_Assignment.Controllers
{
    public class ReviewsController : Controller
    {
        public string AuthToken
        {
            get
            {
                if (HttpContext.Session["AuthToken"] != null)
                    return HttpContext.Session["AuthToken"].ToString();
                return "";
            }
            set {; }
        }

        private WebApiClient _apiClient;

        public WebApiClient apiClient
        {
            get
            {
                return _apiClient ?? new WebApiClient(AuthToken);
            }

            set
            {
                _apiClient = value;
            }

        }

        public ReviewsController()
        {

        }

        public async Task<ActionResult> Index()
        {
            var bindingModel = await apiClient.Get<ReviewListViewModel>("reviews");
            var viewModel = new ReviewIndexViewModel {
                Reviews = bindingModel.Reviews

            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new ReviewNewViewModel();

            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(ReviewNewViewModel viewModel)
        {
            var bindingModel = new ReviewNewViewModel { 
                Agenda = viewModel.Agenda,
                
                Description = viewModel.Description,               
                MaxRate = viewModel.MaxRate,
                MinRate = viewModel.MinRate,
                ReviewCycleStartDate = viewModel.ReviewCycleStartDate,
                ReviewCycleEndDate = viewModel.ReviewCycleEndDate,
            };

            var result = await apiClient.Post<ReviewNewViewModel>("reviews", bindingModel);

            if (!result) { 
                //Add error
            }

            return RedirectToAction("Index");


        }

        public async Task<ActionResult> Assign(int id)
        {
            var bindingModel = await apiClient.Get<EmployeeListViewModel>("employees");

            var employees = bindingModel.Employees;

            var viewModel = new ReviewAssignViewModel {

                Id = id,

                EmployeeSelectList = new MultiSelectList(employees, "Id", "DisplayName"),

                ReviewerSelectList = new SelectList(employees, "Id", "DisplayName"),

            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Assign(ReviewAssignViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var bindingModel = new ReviewAssignBindingModel { 
                EmployeeIds = model.EmployeeIds,
                ReviewerId = model.ReviewerId
            };

            var result= await apiClient.Put<ReviewAssignBindingModel>("reviews/assign", model.Id, bindingModel);

            if (!result) { 
            
                // Add error
            }

            return RedirectToAction("Index");

        }


        public async Task<ActionResult> Submit(int id)
        {
            var bindModel = await apiClient.Get<ReviewGetViewModel>("reviews", id);

            var viewModel = new ReviewSubmitViewModel
            {
                Id = bindModel.Id,
                Employee = bindModel.Employee,
                Reviewer = bindModel.Reviewer,
                Feedback = bindModel.Feedback,
                Rating = (int) bindModel.Rating

            };

            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Submit(ReviewSubmitViewModel viewModel)
        {
            var submitBindingModel = new ReviewSubmitBindingModel
            {
                Rating = viewModel.Rating,
                Feedback = viewModel.Feedback
            };

            var result = await apiClient.Put<ReviewSubmitBindingModel>("reviews/submit", viewModel.Id, submitBindingModel);

            if (!result) { 
                //Add errrors
            
            }

            return RedirectToAction("Index");
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

        //public ActionResult Details(int Id)
        //{


        //    return View();

        //}


    }
}