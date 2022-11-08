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
    public class DepartmentsController : Controller
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

        public DepartmentsController() {
            

        }

        public async Task<ActionResult> Index()
        {
            var bindingModel = await apiClient.Get<DepartmentListViewModel>("departments");

            var viewModel = new DepartmentIndexViewModel
            {
                Departments = bindingModel.Departments
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new DepartmentNewViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(DepartmentNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bindingModel = new DepartmentPostViewModel { Name = viewModel.Name };

                var result = await apiClient.Post<DepartmentPostViewModel>("departments", bindingModel);

                if (result)
                    return RedirectToAction("Index");
            }

            return View(viewModel);

            
        }

        public async Task<ActionResult> Edit(int id)
        {

            var bindingModel = await apiClient.Get<DepartmentGetViewModel>("departments", id);

            var viewModel = new DepartmentEditViewModel { 
                Id = bindingModel.Id,
                Name = bindingModel.Name
            };

            return View(viewModel);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DepartmentEditViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                var bindingModel = new DepartmentPutViewModel { Name = viewModel.Name};

                var result = await apiClient.Put<DepartmentPutViewModel>("departments", viewModel.Id, bindingModel);

                if (result)
                    return RedirectToAction("Index");
                
            }


            return View(viewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {

            var result = await apiClient.Delete("departments", id);

            if (!result) { 
                // Add error
            }

            return RedirectToAction("Index");


        }
    }
}