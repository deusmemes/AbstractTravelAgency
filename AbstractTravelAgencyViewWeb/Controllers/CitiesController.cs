﻿using AbstractTravelAgencyServiceDAL.BindingModel;
using AbstractTravelAgencyServiceDAL.Interfaces;
using System.Web.Mvc;

namespace AbstractTravelAgencyViewWeb.Controllers
{
    public class CitiesController : Controller
    {
        private ICityService service = Globals.CityService;

        public ActionResult List()
        {
            //ViewBag.Cities = service.GetList();
            return View(service.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElement(new CityBindingModel
            {
                CityName = Request["CityName"]
            });
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = service.GetElement(id);
            var bindingModel = new CityBindingModel
            {
                Id = id,
                CityName = viewModel.CityName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdElement(new CityBindingModel
            {
                Id = int.Parse(Request["Id"]),
                CityName = Request["CityName"]
            });
            return RedirectToAction("List");
        }

        public ActionResult More(int id)
        {
            var viewModel = service.GetElement(id);
            
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            service.DelElement(id);
            return RedirectToAction("List");
        }
    }
}