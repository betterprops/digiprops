﻿using PropertyManagementTool.Models;
using PropertyManagementTool.Service;
using PropertyManagementTool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementTool.Controllers
{
    public class AccountsController : Controller
    {
        private IPropertyManagementService Service { get; set; }

        public AccountsController()
        {
            this.Service = new PropertyManagementService();
        }

        // GET: Owners
        public ActionResult Index()
        {
            return View();
        }

        private void OnSelectAccount()
        {
            var list = new SelectList(Service.GetOwnersByUser(User.Identity.Name), "Id", "Name");
            ViewBag.OwnersList = list;
        }

        private void OnCreate()
        {
            var ownerTypes = new SelectList(Service.GetOwnerTypes(), "Id", "Type");
            ViewBag.OwnerTypes = ownerTypes;
        }
       
        public ActionResult SelectAccount()
        {
            OnSelectAccount();
            if (((SelectList)ViewBag.OwnersList).Any())
            {
                if (Session["SelectedAccount"] != null)
                    return View(new SelectOwnerViewModel { Id = ((OwnerModel)Session["SelectedAccount"]).Id });
                else
                    return View();
            }
            return RedirectToAction("Create");
        }

        [HttpPost]
        public ActionResult SelectAccount(SelectOwnerViewModel owner)
        {
            if(owner.Id <= 0)
            {
                ModelState.AddModelError("Id", "You must select an account from the list. If you do not have accounts then create one.");
                OnSelectAccount();
                return View(owner);
            }
            var selectedOwner = Service.GetOwnerById(owner.Id, User.Identity.Name);
            if(selectedOwner != null)
            {
                Session["SelectedAccount"] = selectedOwner;
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Create()
        {
            OnCreate();
            return View();
        }

        [HttpPost]
        public ActionResult Create(OwnerViewModel owner)
        {
            if(!ModelState.IsValid)
            {
                OnCreate();
                return View(owner);
            }
            var ownerModel = new Service.Models.OwnerModel
            {
                Address = owner.Address,
                Name = owner.Name,
                TypeId = owner.TypeId
            };
            if(!Service.CreateOwner(ownerModel, User.Identity.Name))
            {
                return RedirectToAction("Index", "Errors");
            }
            return RedirectToAction("SelectAccount");
        }
    }
}