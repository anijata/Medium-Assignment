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
    public class EmployeeController : Controller
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

        public EmployeeController()
        {
            Context = new ApplicationDbContext();

        }


        public ActionResult Index()
        {

            var CurrentUserId = User.Identity.GetUserId();

            var Organization = Context.Organizations.Where(c => c.ApplicationUserId.Equals(CurrentUserId)).SingleOrDefault();

            var employees = Context.Employees
                .Where(c => c.OrganizationId == Organization.Id)
                .Include(c => c.Country)
                .Include(c => c.State)
                .Include(c => c.City)
                .Include(c => c.ApplicationUser)
                .Include(c => c.Department).ToList();


            var model = new EmployeeIndexViewModel
            {
                Employees = employees

            };

            return View(model);
        }


        public ActionResult New()
        {
            var CurrentUserId = User.Identity.GetUserId();

            var Organization = Context.Organizations.Where(c => c.ApplicationUserId.Equals(CurrentUserId)).SingleOrDefault();

            var countries = Context.Countries.ToList();

            var departments = Context.Departments.Where(c => c.OrganizationId == Organization.Id).ToList();

            var model = new EmployeeNewViewModel
            {
                Employee = new Employee(),
                CountriesSelectList = new SelectList(countries, "Id", "Name"),
                DepartmentsSelectList = new SelectList(departments, "Id", "Name"),
                StatesSelectList = new SelectList(new List<State>()),
                CitiesSelectList = new SelectList(new List<City>())

            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(EmployeeNewViewModel model)
        {
            var CurrentUserId = User.Identity.GetUserId();
            var Organization = Context.Organizations.Where(c => c.ApplicationUserId.Equals(CurrentUserId)).SingleOrDefault();

            if (Organization == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, "Employee");

                    if (result.Succeeded)
                    {
                        model.Employee.ApplicationUserId = user.Id;
                        model.Employee.OrganizationId = Organization.Id;

                        Context.Employees.Add(model.Employee);


                        Context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    AddErrors(result);

                }
                AddErrors(result);

            }


            var departments = Context.Departments.Where(c => c.OrganizationId == Organization.Id).ToList();
            var countries = Context.Countries.ToList();
            var states = Context.States.Where(c => c.CountryId == model.Employee.CountryId).ToList();
            var cities = Context.Cities.Where(c => c.StateId == model.Employee.StateId).ToList();

            model.DepartmentsSelectList = new SelectList(departments, "Id", "Name");
            model.CountriesSelectList = new SelectList(countries, "Id", "Name", model.Employee.CountryId);
            model.StatesSelectList = new SelectList(states, "Id", "Name", model.Employee.StateId);
            model.CitiesSelectList = new SelectList(cities, "Id", "Name", model.Employee.CityId);


            return View(model);

        }

        public ActionResult Edit(int Id)
        {

            var CurrentUserId = User.Identity.GetUserId();
            var Organization = Context.Organizations.Where(c => c.ApplicationUserId.Equals(CurrentUserId)).SingleOrDefault();

            if (Organization == null)
                return HttpNotFound();

            var employee = Context.Employees.Include(c => c.ApplicationUser).SingleOrDefault(c => c.Id == Id);
            var countries = Context.Countries.ToList();
            var states = Context.States.Where(c => c.CountryId == employee.CountryId).ToList();
            var cities = Context.Cities.Where(c => c.StateId == employee.StateId).ToList();
            var departments = Context.Departments.Where(c => c.OrganizationId == Organization.Id).ToList();

            if (employee == null)
            {
                return HttpNotFound();
            }

            var model = new EmployeeEditViewModel
            {
                Employee= employee,
                UserName = employee.ApplicationUser.UserName,
                PhoneNumber = employee.ApplicationUser.PhoneNumber,
                Email = employee.ApplicationUser.Email,
                CountriesSelectList = new SelectList(countries, "Id", "Name", employee.CountryId),
                StatesSelectList = new SelectList(states, "Id", "Name", employee.StateId),
                CitiesSelectList = new SelectList(cities, "Id", "Name", employee.CityId),
                DepartmentsSelectList = new SelectList(departments, "Id", "Name")

            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeEditViewModel model)
        {

            var CurrentUserId = User.Identity.GetUserId();
            var Organization = Context.Organizations.Where(c => c.ApplicationUserId.Equals(CurrentUserId)).SingleOrDefault();

            if (Organization == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(model.Employee.ApplicationUserId);
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;

                var result = await UserManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    var employee = Context.Employees.SingleOrDefault(m => m.Id == model.Employee.Id);

                    employee.FirstName = model.Employee.FirstName;
                    employee.LastName = model.Employee.LastName;
                    employee.DOB = model.Employee.DOB;
                    employee.Gender = model.Employee.Gender;
                    employee.Designation = model.Employee.Designation;
                    employee.DOJ = model.Employee.DOJ;
                    employee.DepartmentId = model.Employee.DepartmentId;
                    employee.Address1 = model.Employee.Address1;
                    employee.Address2 = model.Employee.Address2;
                    employee.CountryId = model.Employee.CountryId;
                    employee.StateId = model.Employee.StateId;
                    employee.CityId = model.Employee.CityId;
                    employee.EmployeeType = model.Employee.EmployeeType;
                    employee.Status = model.Employee.Status;

                    Context.SaveChanges();
                    return RedirectToAction("Index");

                }
                AddErrors(result);
            }


            var departments = Context.Departments.Where(c => c.OrganizationId == Organization.Id).ToList();
            var countries = Context.Countries.ToList();
            var states = Context.States.Where(c => c.CountryId == model.Employee.CountryId).ToList();
            var cities = Context.Cities.Where(c => c.StateId == model.Employee.StateId).ToList();

            model.DepartmentsSelectList = new SelectList(departments, "Id", "Name");
            model.CountriesSelectList = new SelectList(countries, "Id", "Name", model.Employee.CountryId);
            model.StatesSelectList = new SelectList(states, "Id", "Name", model.Employee.StateId);
            model.CitiesSelectList = new SelectList(cities, "Id", "Name", model.Employee.CityId);


            return View(model);
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
            var employee = Context.Employees.SingleOrDefault(c => c.Id == Id);

            if (employee == null)
                return HttpNotFound();

            var user = await UserManager.FindByIdAsync(employee.ApplicationUserId);

            var result = await UserManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return HttpNotFound();
            }

            Context.Employees.Remove(employee);

            Context.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Details(int Id)
        {
            var employee = Context.Employees
                .Include(c => c.Country)
                .Include(c => c.State)
                .Include(c => c.City)
                .Include(c => c.Department)
                .Include(c => c.ApplicationUser)
                .SingleOrDefault(c => c.Id == Id);

            if (employee == null)
                return HttpNotFound();


            var viewModel = new EmployeeDetailsViewModel { Employee = employee };


            return View(viewModel);

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