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
    public class OrganizationsController : Controller
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

        public WebApiClient apiClient {
            get {
                return _apiClient ?? new WebApiClient(AuthToken);                      
            }

            set
            {
                _apiClient = value;
            }

        }

        public OrganizationsController()
        {
            
        }

        public async Task<ActionResult> Details(int id)
        {

            var bindingModel = await apiClient.Get<OrganizationGetViewModel>("organizations", id); ;

            var viewModel = new OrganizationDetailsViewModel {
                Organization = bindingModel
            };

            return View(viewModel);
        }

        public async Task<ActionResult> Index()
        {


            var bindingModel = await apiClient.Get<OrganizationListViewModel>("organizations"); ;

            var viewModel = new OrganizationIndexViewModel
            {
                Organizations = bindingModel.Organizations
            };

            return View(viewModel);
        }

        public ActionResult New()
        {

            var model = new OrganizationNewViewModel();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(OrganizationNewViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var bindingModel = new OrganizationPostViewModel { 
                Name = model.Name,
                UserName = model.UserName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                CityId = model.CityId,
                CountryId = model.CountryId,
                StateId = model.StateId,
                Description = model.Description,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Status = model.Status
            };

            var result = await apiClient.Post<OrganizationPostViewModel>("organizations", bindingModel);

            if (!result)
                return View(model);

            return RedirectToAction("Index");


        }

        public async Task<ActionResult> Edit(int id)
        {

            var bindingModel = await apiClient.Get<OrganizationGetViewModel>("organizations", id);

            var viewModel = new OrganizationEditViewModel{
                Name = bindingModel.Name,
                UserName = bindingModel.UserName,
                PhoneNumber = bindingModel.PhoneNumber,
                Email = bindingModel.Email,
                Address1 = bindingModel.Address1,
                Address2 = bindingModel.Address2,
                CountryId = bindingModel.CountryId,
                StateId = bindingModel.StateId,
                CityId = bindingModel.CityId,                
                Description = bindingModel.Description,             
                Status = bindingModel.Status
            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrganizationEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);


            var bindingModel = new OrganizationPutViewModel { 
                Name = viewModel.Name,
                UserName = viewModel.UserName,
                PhoneNumber = viewModel.PhoneNumber,
                Email = viewModel.Email,
                Address1 = viewModel.Address1,
                Address2 = viewModel.Address2,
                CountryId = viewModel.CountryId,
                StateId = viewModel.StateId,
                CityId = viewModel.CityId,
                Status = viewModel.Status,
                Description = viewModel.Description            
            };

            var result = await apiClient.Put<OrganizationPutViewModel>("organizations", viewModel.Id, bindingModel);

            if (!result)
                return View(viewModel);

            return RedirectToAction("Index");
        }

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}




        public async Task<ActionResult> Delete(int id) {


            var result = await apiClient.Delete("organizations", id);

            return RedirectToAction("Index");
        }


    }
}
