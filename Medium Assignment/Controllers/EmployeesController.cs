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
    public class EmployeesController : Controller
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

        public EmployeesController()
        {

        }

        public async Task<List<Department>> GetDepartments()
        {

            var departmentsBindingModel = await apiClient.Get<DepartmentListViewModel>("departments");

            return departmentsBindingModel
                    .Departments
                    .Select(m => new Department { Id = m.Id, Name = m.Name })
                    .ToList();
        }

        public async Task<ActionResult> Details(int id)
        {
            var bindingModel = await apiClient.Get<EmployeeGetViewModel>("employees", id);

            var viewModel = new EmployeeDetailsViewModel { Employee = bindingModel };


            return View(viewModel);

        }


        public async Task<ActionResult> Index()
        {
            var bindingModel = await apiClient.Get<EmployeeListViewModel>("employees");

            var model = new EmployeeIndexViewModel
            {
                Employees = bindingModel.Employees

            };

            return View(model);
        }


        public async Task<ActionResult> New()
        {
            var departments = await GetDepartments();

            var viewModel = new EmployeeNewViewModel {

                DepartmentsSelectList = new SelectList(departments, "Id", "Name")
            };

            return View(viewModel);
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(EmployeeNewViewModel viewModel)
        {
            
            if (ModelState.IsValid) {
                var bindingModel = new EmployeePostViewModel
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    UserName = viewModel.UserName,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    Address1 = viewModel.Address1,
                    Address2 = viewModel.Address2,
                    CountryId = viewModel.CountryId,
                    StateId = viewModel.StateId,
                    CityId = viewModel.CityId,
                    DepartmentId = viewModel.DepartmentId,
                    Designation = viewModel.Designation,
                    DOB = viewModel.DOB,
                    DOJ = viewModel.DOJ,
                    EmployeeType = viewModel.EmployeeType,
                    Gender = viewModel.Gender,
                    Status = viewModel.Status
                };

                var result = await apiClient.Post<EmployeePostViewModel>("employees", bindingModel);

                if (result)
                    return RedirectToAction("Index");

            }

            
            var departments = await GetDepartments();

            viewModel.DepartmentsSelectList = new SelectList(departments, "Id", "Name", viewModel.DepartmentId);

            return View(viewModel);

        }

        public async Task<ActionResult> Edit(int id)
        {
            var departments = await GetDepartments();

            var bindingModel = await apiClient.Get<EmployeeGetViewModel>("employees", id);

            var viewModel = new EmployeeEditViewModel
            {
                Id = bindingModel.Id,
                FirstName = bindingModel.FirstName,
                LastName = bindingModel.LastName,
                UserName = bindingModel.UserName,
                Email = bindingModel.Email,
                PhoneNumber = bindingModel.PhoneNumber,
                Address1 = bindingModel.Address1,
                Address2 = bindingModel.Address2,
                CountryId = bindingModel.CountryId,
                StateId = bindingModel.StateId,
                CityId = bindingModel.CityId,
                DepartmentId = bindingModel.DepartmentId,
                Designation = bindingModel.Designation,
                DOB = bindingModel.DOB,
                DOJ = bindingModel.DOJ,
                EmployeeType = bindingModel.EmployeeType,
                Gender = bindingModel.Gender,
                Status = bindingModel.Status,
                DepartmentsSelectList = new SelectList(departments, "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeEditViewModel viewModel)
        {
            if (ModelState.IsValid) {

                var bindingModel = new EmployeePutViewModel
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    UserName = viewModel.UserName,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email = viewModel.Email,
                    Address1 = viewModel.Address1,
                    Address2 = viewModel.Address2,
                    CountryId = viewModel.CountryId,
                    StateId = viewModel.StateId,
                    CityId = viewModel.CityId,
                    DepartmentId = viewModel.DepartmentId,
                    Designation = viewModel.Designation,
                    DOB = viewModel.DOB,
                    DOJ = viewModel.DOJ,
                    EmployeeType = viewModel.EmployeeType,
                    Gender = viewModel.Gender,
                    Status = viewModel.Status

                };

                var result = await apiClient.Put<EmployeePutViewModel>("employees", viewModel.Id, bindingModel);

                if (result)
                    return RedirectToAction("Index");
            }

            var departments = await GetDepartments();

            viewModel.DepartmentsSelectList = new SelectList(departments, "Id", "Name", viewModel.DepartmentId);

            return View(viewModel);
        }

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}



        public async Task<ActionResult> Delete(int id)
        {
            var result = await apiClient.Delete("employees", id);

            if (!result) { 
                // Add error.
            }

            return RedirectToAction("Index");


        }


    }
}