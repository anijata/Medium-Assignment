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
    [Authorize(Roles = "OrganizationAdmin")]
    public class ReviewController : Controller
    {
        private ApplicationDbContext Context;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ReviewController()
        {
            Context = new ApplicationDbContext();

        }

        public int GetOrganizationId() { 
        
            var CurrentUserId = User.Identity.GetUserId();
            var OrganizationId = Context.Organizations
                .Where(c => !c.IsDeleted && c.ApplicationUserId.Equals(CurrentUserId))
                .Select(c => c.Id)
                .SingleOrDefault();

            return OrganizationId;
        }


        public ActionResult Index()
        {
            var OrganizationId = GetOrganizationId();

            var reviews = Context.Reviews
                .Where(c => c.OrganizationId == OrganizationId && !c.IsDeleted)
                .Include(c => c.Employee)
                .Include(c => c.Employee.ApplicationUser)
                .Include(c => c.Reviewer)
                .Include(c => c.Reviewer.ApplicationUser)
                .Include(c => c.ReviewStatus)
                .ToList();

            var model = new ReviewIndexViewModel
            {
                Reviews = reviews
            };

            return View(model);

        }

        public ActionResult New()
        {
            var model = new ReviewNewViewModel();

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(ReviewNewViewModel model)
        {
            var CurrentUserId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var review = new Review
            {
                Agenda = model.Agenda,

                ReviewCycleStartDate = model.ReviewCycleStartDate,

                ReviewCycleEndDate = model.ReviewCycleEndDate,

                MinRate = model.MinRate,

                MaxRate = model.MaxRate,

                Description = model.Description,

                OrganizationId = GetOrganizationId(),

                ReviewStatusId = 1,

                CreatedBy = CurrentUserId,

                CreatedOn = DateTime.Now,

                ModifiedBy = CurrentUserId,

                ModifiedOn = DateTime.Now
            };

            Context.Reviews.Add(review);

            Context.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Assign(int Id) {

            var OrganizationId = GetOrganizationId();

            var review = Context.Reviews
                .Where(c => c.OrganizationId == OrganizationId && !c.IsDeleted && c.Id == Id && c.ReviewStatusId == 1)
                .SingleOrDefault();

            if (review == null)
            {
                return HttpNotFound();
            }

            var employees = Context.Employees
                .Where(c => c.OrganizationId == OrganizationId && !c.IsDeleted)
                .Include(c => c.ApplicationUser)
                .ToList();

            var model = new ReviewAssignReviewViewModel()
            {
                Id = review.Id,
                EmployeeIds = new List<int>(),
                EmployeeSelectList = new MultiSelectList(employees, "Id", "DisplayName"),
                ReviewerSelectList = new SelectList(employees, "Id", "DisplayName")

            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(ReviewAssignReviewViewModel model)
        {

            var CurrentUserId = User.Identity.GetUserId();

            var OrganizationId = GetOrganizationId();


            var review = Context.Reviews
                .Where(c => c.OrganizationId == OrganizationId
                            && !c.IsDeleted && c.Id == model.Id
                            && c.ReviewStatusId == 1)
                .SingleOrDefault();

            if (review == null)
            {
                return HttpNotFound();
            }

            var employees = Context.Employees
                .Where(c => c.OrganizationId == OrganizationId && !c.IsDeleted)
                .Include(c => c.ApplicationUser)
                .ToList();

            if (!ModelState.IsValid)
            {
                model.EmployeeSelectList = new MultiSelectList(employees, "Id", "DisplayName", model.EmployeeIds);

                model.ReviewerSelectList = new SelectList(employees, "Id", "DisplayName", model.ReviewerId);

                return View(model);
            }

            review.EmployeeId = model.EmployeeIds[0];
            review.ReviewerId = model.ReviewerId;
            review.ReviewStatusId = 2;
            review.ModifiedBy = CurrentUserId;
            review.ModifiedOn = DateTime.Now;

            model.EmployeeIds.RemoveAt(0);

            foreach (var employeeid in model.EmployeeIds) {
                var newReview = new Review
                {
                    Agenda = review.Agenda,

                    ReviewerId = model.ReviewerId,

                    EmployeeId = employeeid,

                    ReviewCycleStartDate = review.ReviewCycleStartDate.Date,

                    ReviewCycleEndDate = review.ReviewCycleEndDate.Date,

                    MinRate = review.MinRate,

                    MaxRate = review.MaxRate,

                    Description = review.Description,

                    OrganizationId = review.OrganizationId,

                    ReviewStatusId = review.ReviewStatusId,

                    CreatedBy = CurrentUserId,

                    CreatedOn = DateTime.Now,

                    ModifiedBy = CurrentUserId,

                    ModifiedOn = DateTime.Now

            };

                Context.Reviews.Add(newReview);


            }

            
            Context.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Submit(int Id) {

            var CurrentUserId = User.Identity.GetUserId();

            var OrganizationId = GetOrganizationId();

            var review = Context.Reviews
                .Where(c => c.OrganizationId == OrganizationId && !c.IsDeleted && c.Id == Id && c.ReviewStatusId == 2)
                .Include(c => c.Reviewer)
                .Include(c => c.Reviewer.ApplicationUser)
                .Include(c => c.Employee)
                .Include(c => c.Employee.ApplicationUser)
                .SingleOrDefault();

            if (review == null)
            {
                return HttpNotFound();
            }


            var model = new ReviewSubmitReviewViewModel 
            { 
                Id = review.Id,
                ReviewerDisplayName = review.Reviewer.DisplayName,
                EmployeeDisplayName = review.Employee.DisplayName,
              
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(ReviewSubmitReviewViewModel model)
        {
            var CurrentUserId = User.Identity.GetUserId();

            var OrganizationId = GetOrganizationId();

            var review = Context.Reviews
                .Where(c => c.OrganizationId == OrganizationId && !c.IsDeleted && c.Id == model.Id && c.ReviewStatusId == 2)
                .SingleOrDefault();

            if (review == null)
            {
                return HttpNotFound();
            }

            review.Rating = model.Rating;
            review.Feedback = model.Feedback;
            review.ReviewStatusId = 3;
            review.ModifiedBy = CurrentUserId;
            review.ModifiedOn = DateTime.Now;
            

            Context.Reviews.Add(review);

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }




        public async Task<ActionResult> Delete(int Id)
        {
            //var organization = Context.Organizations.SingleOrDefault(c => c.Id == Id);

            //if (organization == null)
            //    return HttpNotFound();

            //var user = await UserManager.FindByIdAsync(organization.ApplicationUserId);

            //var result = await UserManager.DeleteAsync(user);

            //if (!result.Succeeded)
            //{
            //    return HttpNotFound();
            //}

            //Context.Organizations.Remove(organization);

            //Context.SaveChanges();

            //return RedirectToAction("Index");

            return View();


        }

        public ActionResult Details(int Id)
        {
            //var organization = Context.Organizations
            //    .Include(c => c.Country)
            //    .Include(c => c.State)
            //    .Include(c => c.City)
            //    .Include(c => c.ApplicationUser)
            //    .SingleOrDefault(c => c.Id == Id);

            //if (organization == null)
            //    return HttpNotFound();


            //var viewModel = new OrganizationDetailsViewModel { Organization = organization };


            //return View(viewModel);

            return View();

        }

        [HttpPost]
        public ActionResult GetStates(string countryId)
        {

            List<SelectListItem> items = new List<SelectListItem>();


            if (string.IsNullOrEmpty(countryId))
            {
                return Json(items);
            }

            var id = Convert.ToInt32(countryId);


            var states = Context.States.Where(c => c.CountryId == id).ToList();


            states.ForEach(i => items.Add(new SelectListItem { Text = i.Name, Value = i.Id.ToString() }));

            return Json(items);


        }

        [HttpPost]

        public ActionResult GetCities(string stateId)
        {
            List<SelectListItem> items = new List<SelectListItem>();


            if (string.IsNullOrEmpty(stateId))
            {
                return Json(items);
            }

            var id = Convert.ToInt32(stateId);


            var cities = Context.Cities.Where(c => c.StateId == id).ToList();


            cities.ForEach(i => items.Add(new SelectListItem { Text = i.Name, Value = i.Id.ToString() }));

            return Json(items);


        }
    }
}