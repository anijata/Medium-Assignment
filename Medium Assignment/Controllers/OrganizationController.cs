using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medium_Assignment.Models;
using Medium_Assignment.ViewModels;
using System.Data.Entity;


namespace Simple_Assignment.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization

        private ApplicationDbContext Context;

        public OrganizationController() {
            Context = new ApplicationDbContext();

        }

        public ActionResult Index()
        {
            var model = new IndexOrganizationViewModel {
                Organizations = Context.Organizations
                .Include(c => c.Country)
                .Include(c => c.State)
                .Include(c => c.City)
                .Include(c => c.ApplicationUser)
                .Where(c => c.Status.Equals("Active"))
                .ToList()
            };

            return View(model);
        }

        public ActionResult New()
        {
            var countries = Context.Countries.ToList();

            var model = new OrganizationFormViewModel
            {
                //Organization = new Organization(),
                //CountriesSelectList = new SelectList(countries, "Id", "Name"),
                //StatesSelectList = new SelectList(new List<State>()),
                //CitiesSelectList = new SelectList(new List<City>())

            };

            return View("Form", model);
        }

        public ActionResult Edit(int Id) {
            var organization = Context.Organizations.SingleOrDefault(c => c.Id == Id);
            var countries = Context.Countries.ToList();
            var states = Context.States.Where(c => c.CountryId == organization.CountryId).ToList();
            var cities = Context.Cities.Where(c => c.StateId == organization.StateId).ToList();

            if (organization == null) {
                return HttpNotFound();          
            }

            var model = new OrganizationFormViewModel
            {
                //Organization = organization,
                //CountriesSelectList = new SelectList(countries, "Id", "Name", organization.CountryId),
                //StatesSelectList = new SelectList(states, "Id", "Name", organization.StateId),
                //CitiesSelectList = new SelectList(cities, "Id", "Name", organization.CityId)

            };

            return View("Form", model);

        }

        [HttpPost]
        public ActionResult Save(Organization organization) {
            if (!ModelState.IsValid) {
                var countries = Context.Countries.ToList();
                var states = Context.States.Where(c => c.CountryId == organization.CountryId).ToList();
                var cities = Context.Cities.Where(c => c.StateId == organization.StateId).ToList();


                var model = new OrganizationFormViewModel
                {
                    //Organization = organization,
                    //CountriesSelectList = new SelectList(countries, "Id", "Name", organization.CountryId),
                    //StatesSelectList = new SelectList(states, "Id", "Name", organization.StateId),
                    //CitiesSelectList = new SelectList(cities, "Id", "Name", organization.CityId)

            };

                return View("Form", model);

            }


            if (organization.Id == 0)
            {
                Context.Organizations.Add(organization);
            }
            else {

                var _organization = Context.Organizations.SingleOrDefault(m => m.Id == organization.Id);

                //_organization.Name = organization.Name;
                //_organization.PhoneNumber = organization.PhoneNumber;
                //_organization.Email = organization.Email;
                //_organization.UserId = organization.UserId;
                //_organization.Password = organization.Password;
                //_organization.Address1 = organization.Address1;
                //_organization.Address2 = organization.Address2;
                //_organization.Country = organization.Country;
                //_organization.StateId = organization.StateId;
                //_organization.CityId = organization.CityId;
                //_organization.Status = organization.Status;
                //_organization.Description = organization.Description;


            }


            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var organization = Context.Organizations.SingleOrDefault(c => c.Id == Id);

            if (organization == null)
                return HttpNotFound();

            organization.Status = "Inactive";

            Context.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Details(int Id) {
            var organization = Context.Organizations
                .Include(c => c.Country)
                .Include(c => c.State)
                .Include(c => c.City)
                .SingleOrDefault(c => c.Id == Id);

            if (organization == null)
                return HttpNotFound();


            var viewModel = new DetailsViewModel { Organization = organization };


            return View(viewModel);

        }

        [HttpPost]
        public ActionResult GetStates(string countryId) {

            List<SelectListItem> items = new List<SelectListItem>();


            if (string.IsNullOrEmpty(countryId)) { 
                return Json(items);
            }

            var id = Convert.ToInt32(countryId);

            
            var states = Context.States.Where(c => c.CountryId == id).ToList();


            states.ForEach(i => items.Add(new SelectListItem {Text = i.Name, Value = i.Id.ToString()}));

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