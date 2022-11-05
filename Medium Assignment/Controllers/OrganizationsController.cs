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
    public class OrganizationController : Controller
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

        public OrganizationController()
        {

        }

        //public ActionResult Details(int Id)
        //{
        //    var client = new WebApiClient(AuthToken);


        //    if (organization == null)
        //        return HttpNotFound();


        //    var viewModel = new OrganizationDetailsViewModel { Organization = organization };


        //    return View(viewModel);
        //}

        // Http actions

        public async Task<ActionResult> Index()
        {

            var client = new WebApiClient(AuthToken);

            var model = await client.Get<OrganizationListViewModel>("organizations");

            return View(model);
        }

        public ActionResult New()
        {
            var client = new WebApiClient(AuthToken);

            var model = new OrganizationNewViewModel
            {
                CountriesSelectList = new SelectList(new List<Country>()),
                StatesSelectList = new SelectList(new List<State>()),
                CitiesSelectList = new SelectList(new List<City>())
            };

            return View(model);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken] 
        //public async Task<ActionResult> New(OrganizationNewViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, PhoneNumber = model.PhoneNumber };
        //        var result = await UserManager.CreateAsync(user, model.Password);

        //        if (result.Succeeded)
        //        {
        //            result = await UserManager.AddToRoleAsync(user.Id, "OrganizationAdmin");

        //            if (result.Succeeded)
        //            {
        //                model.Organization.ApplicationUserId = user.Id;
        //                model.Organization.CreatedBy = User.Identity.GetUserId();
        //                model.Organization.CreatedOn = DateTime.Now;
        //                model.Organization.ModifiedBy = User.Identity.GetUserId();
        //                model.Organization.ModifiedOn = DateTime.Now;


        //                Context.Organizations.Add(model.Organization);
        //                Context.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            AddErrors(result);

        //        }
        //        AddErrors(result);

        //    }


        //    var countries = Context.Countries.ToList();
        //    var states = Context.States.Where(c => c.CountryId == model.Organization.CountryId).ToList();
        //    var cities = Context.Cities.Where(c => c.StateId == model.Organization.StateId).ToList();


        //    model.CountriesSelectList = new SelectList(countries, "Id", "Name", model.Organization.CountryId);
        //    model.StatesSelectList = new SelectList(states, "Id", "Name", model.Organization.StateId);
        //    model.CitiesSelectList = new SelectList(cities, "Id", "Name", model.Organization.CityId);


        //    return View(model);


        //}

        //public ActionResult Edit(int Id)
        //{
        //    var organization = Context.Organizations
        //        .Where(c => !c.IsDeleted)
        //        .Include(c => c.ApplicationUser)
        //        .SingleOrDefault(c => c.Id == Id);

        //    var countries = Context.Countries.ToList();
        //    var states = Context.States.Where(c => c.CountryId == organization.CountryId).ToList();
        //    var cities = Context.Cities.Where(c => c.StateId == organization.StateId).ToList();

        //    if (organization == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var model = new OrganizationEditViewModel
        //    {
        //        Organization = organization,
        //        UserName = organization.ApplicationUser.UserName,
        //        PhoneNumber = organization.ApplicationUser.PhoneNumber,
        //        Email = organization.ApplicationUser.Email,
        //        CountriesSelectList = new SelectList(countries, "Id", "Name", organization.CountryId),
        //        StatesSelectList = new SelectList(states, "Id", "Name", organization.StateId),
        //        CitiesSelectList = new SelectList(cities, "Id", "Name", organization.CityId)

        //    };

        //    return View(model);

        // }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(OrganizationEditViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserManager.FindByIdAsync(model.Organization.ApplicationUserId);

        //        user.Email = model.Email;
        //        user.UserName = model.UserName;
        //        user.PhoneNumber = model.PhoneNumber;

        //        var result = await UserManager.UpdateAsync(user);

        //        if (result.Succeeded)
        //        {

        //            var _organization = Context.Organizations.Where(c => !c.IsDeleted).SingleOrDefault(m => m.Id == model.Organization.Id);
        //            _organization.Name = model.Organization.Name;
        //            _organization.Address1 = model.Organization.Address1;
        //            _organization.Address2 = model.Organization.Address2;
        //            _organization.CountryId = model.Organization.CountryId;
        //            _organization.StateId = model.Organization.StateId;
        //            _organization.CityId = model.Organization.CityId;
        //            _organization.Status = model.Organization.Status;
        //            _organization.Description = model.Organization.Description;
        //            _organization.ModifiedBy = User.Identity.GetUserId();
        //            _organization.ModifiedOn = DateTime.Now;

        //            Context.SaveChanges();

        //            return RedirectToAction("Index");



        //        }
        //        AddErrors(result);

        //    }



        //    var countries = Context.Countries.ToList();
        //    var states = Context.States.Where(c => c.CountryId == model.Organization.CountryId).ToList();
        //    var cities = Context.Cities.Where(c => c.StateId == model.Organization.StateId).ToList();


        //    model.CountriesSelectList = new SelectList(countries, "Id", "Name", model.Organization.CountryId);
        //    model.StatesSelectList = new SelectList(states, "Id", "Name", model.Organization.StateId);
        //    model.CitiesSelectList = new SelectList(cities, "Id", "Name", model.Organization.CityId);


        //    return View(model);
        //}

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}




        //public async Task<ActionResult> Delete(int Id)
        //{
        //    var organization = Context.Organizations.SingleOrDefault(c => c.Id == Id);

        //    if (organization == null)
        //        return HttpNotFound();

        //    var user = await UserManager.FindByIdAsync(organization.ApplicationUserId);

        //    var result = await UserManager.DeleteAsync(user);

        //    if (!result.Succeeded)
        //    {
        //        return HttpNotFound();
        //    }

        //    Context.Organizations.Remove(organization);

        //    Context.SaveChanges();

        //    return RedirectToAction("Index");


        //}

        
            

            //[HttpPost]
            //public ActionResult GetStates(string countryId)
            //{

            //    List<SelectListItem> items = new List<SelectListItem>();


            //    if (string.IsNullOrEmpty(countryId))
            //    {
            //        return Json(items);
            //    }

            //    var id = Convert.ToInt32(countryId);


            //    var states = Context.States.Where(c => c.CountryId == id).ToList();


            //    states.ForEach(i => items.Add(new SelectListItem { Text = i.Name, Value = i.Id.ToString() }));

            //    return Json(items);


            //}

            //[HttpPost]

            //public ActionResult GetCities(string stateId)
            //{
            //    List<SelectListItem> items = new List<SelectListItem>();


            //    if (string.IsNullOrEmpty(stateId))
            //    {
            //        return Json(items);
            //    }

            //    var id = Convert.ToInt32(stateId);


            //    var cities = Context.Cities.Where(c => c.StateId == id).ToList();


            //    cities.ForEach(i => items.Add(new SelectListItem { Text = i.Name, Value = i.Id.ToString() }));

            //    return Json(items);


            //}

        }
}
