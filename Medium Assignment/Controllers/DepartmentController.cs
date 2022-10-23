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
    [Authorize(Roles ="OrganizationAdmin")]
    public class DepartmentController : Controller
    {
        // GET: Department

        private ApplicationDbContext Context;

        public DepartmentController() {
            Context = new ApplicationDbContext();

        }

        public ActionResult Index()
        {
            var CurrentUserId = User.Identity.GetUserId();

            var OrganizationId = Context.Organizations
                .Where(c => !c.IsDeleted && c.ApplicationUserId.Equals(CurrentUserId))
                .Select(c => c.Id)
                .FirstOrDefault();

            var Departments = Context.Departments.Where(c => c.OrganizationId.Equals(OrganizationId)).ToList();

            var model = new DepartmentIndexViewModel
            {
                Departments = Departments
            };

            return View(model);
        }

        public ActionResult New() {
            var model = new DepartmentNewViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(DepartmentNewViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var CurrentUserId = User.Identity.GetUserId();

            var OrganizationId = Context.Organizations
                .Where(c => !c.IsDeleted && c.ApplicationUserId.Equals(CurrentUserId))
                .Select(c => c.Id)
                .FirstOrDefault();

            var department = new Department
            {
                Name = model.Name,
                OrganizationId = OrganizationId,
                CreatedOn = DateTime.Now,
                CreatedBy = User.Identity.GetUserId(),
                ModifiedOn = DateTime.Now,
                ModifiedBy = User.Identity.GetUserId()
            };

            Context.Departments.Add(department);

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id) {

            var department = Context.Departments.Where(c => c.Id == Id).FirstOrDefault();


            if (department == null) {
                return HttpNotFound();
            }

            var model = new DepartmentEditViewModel 
            {
                Id = department.Id,
                Name = department.Name
            
            };

            return View(model);

 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var department = Context.Departments.Where(c => !c.IsDeleted && c.Id == model.Id).SingleOrDefault();

            if (department == null)
            {
                return HttpNotFound();
            }

            department.Name = model.Name;
            department.ModifiedOn = DateTime.Now;
            department.ModifiedBy = User.Identity.GetUserId();

            Context.SaveChanges();

            return RedirectToAction("Index");


        }

        public async Task<ActionResult> Delete(int Id)
        {
            var department = Context.Departments.Where(c => !c.IsDeleted).SingleOrDefault(c => c.Id == Id);

            if (department == null)
                return HttpNotFound();

            department.IsDeleted = true;

            Context.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}