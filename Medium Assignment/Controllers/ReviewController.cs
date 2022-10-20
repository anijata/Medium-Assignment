﻿using System;
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



        public ActionResult Create()
        {
            var countries = Context.Countries.ToList();

            var model = new ReviewCreateViewModel();

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var CurrentUserId = User.Identity.GetUserId();
            var OrganizationId = Context.Organizations.Where(c => c.ApplicationUserId.Equals(CurrentUserId)).Select(c => c.Id).SingleOrDefault();


            var review = new Review {
                Agenda = model.Agenda,

                ReviewCycleStartDate = model.ReviewCycleStartDate,

                ReviewCycleEndDate = model.ReviewCycleEndDate,

                MinRate = model.MinRate,

                MaxRate = model.MaxRate,

                Description = model.Description,

                OrganizationId = OrganizationId,

                ReviewStatusId = 1
            };

            Context.Reviews.Add(review);

            Context.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Index()
        {
            var model = new ReviewIndexViewModel
            {
                Reviews = Context.Reviews.Include(c => c.ReviewStatus).ToList()
            };

            return View(model);

        }

        public ActionResult Assign(int Id) {

            var review = Context.Reviews.Include(c => c.ReviewStatus).Where(c => c.Id == Id && c.ReviewStatusId != 3 ).SingleOrDefault();
            var employees = Context.Employees.ToList();

            if (review == null) {
                return HttpNotFound();
            }

            var model = new ReviewAssignReviewViewModel() {
                Id = review.Id,
                EmployeeIds = new List<int?>(),
                ReviewerId = review.ReviewerId,

                EmployeeSelectList = new SelectList(employees, "Id", "FirstName"),
                ReviewerSelectList = new SelectList(employees, "Id", "FirstName")

            };

            

            return View(model);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(ReviewAssignReviewViewModel model)
        {
            //var employees = Context.Employees.ToList();

            //var review = Context.Reviews.Include(c => c.ReviewStatus).Where(c => c.ReviewStatusId != 3 && c.Id == model.Id).SingleOrDefault();

            

            //if (!ModelState.IsValid) {

            //    model.EmployeeSelectList = new SelectList(employees, "Id", "FirstName", model.EmployeeId);

            //    model.ReviewerSelectList = new SelectList(employees, "Id", "FirstName", model.ReviewerId);

            //    return View(model);
            //}

            //review.EmployeeId = model.EmployeeId;
            //review.ReviewerId = model.ReviewerId;

            //review.ReviewStatusId = 3;

            //Context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int Id)
        {
            //var organization = Context.Organizations.Include(c => c.ApplicationUser).SingleOrDefault(c => c.Id == Id);
            //var countries = Context.Countries.ToList();
            //var states = Context.States.Where(c => c.CountryId == organization.CountryId).ToList();
            //var cities = Context.Cities.Where(c => c.StateId == organization.StateId).ToList();

            //if (organization == null)
            //{
            //    return HttpNotFound();
            //}

            //var model = new OrganizationEditViewModel
            //{
            //    Organization = organization,
            //    UserName = organization.ApplicationUser.UserName,
            //    PhoneNumber = organization.ApplicationUser.PhoneNumber,
            //    Email = organization.ApplicationUser.Email,
            //    CountriesSelectList = new SelectList(countries, "Id", "Name", organization.CountryId),
            //    StatesSelectList = new SelectList(states, "Id", "Name", organization.StateId),
            //    CitiesSelectList = new SelectList(cities, "Id", "Name", organization.CityId)

            //};

            //return View(model);

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrganizationEditViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var user = await UserManager.FindByIdAsync(model.Organization.ApplicationUserId);

            //    user.Email = model.Email;
            //    user.UserName = model.UserName;
            //    user.PhoneNumber = model.PhoneNumber;

            //    var result = await UserManager.UpdateAsync(user);

            //    if (result.Succeeded)
            //    {

            //        var _organization = Context.Organizations.SingleOrDefault(m => m.Id == model.Organization.Id);
            //        _organization.Name = model.Organization.Name;
            //        _organization.Address1 = model.Organization.Address1;
            //        _organization.Address2 = model.Organization.Address2;
            //        _organization.CountryId = model.Organization.CountryId;
            //        _organization.StateId = model.Organization.StateId;
            //        _organization.CityId = model.Organization.CityId;
            //        _organization.Status = model.Organization.Status;
            //        _organization.Description = model.Organization.Description;

            //        Context.SaveChanges();

            //        return RedirectToAction("Index");



            //    }
            //    AddErrors(result);

            //}



            //var countries = Context.Countries.ToList();
            //var states = Context.States.Where(c => c.CountryId == model.Organization.CountryId).ToList();
            //var cities = Context.Cities.Where(c => c.StateId == model.Organization.StateId).ToList();


            //model.CountriesSelectList = new SelectList(countries, "Id", "Name", model.Organization.CountryId);
            //model.StatesSelectList = new SelectList(states, "Id", "Name", model.Organization.StateId);
            //model.CitiesSelectList = new SelectList(cities, "Id", "Name", model.Organization.CityId);


            //return View(model);

            return View();
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