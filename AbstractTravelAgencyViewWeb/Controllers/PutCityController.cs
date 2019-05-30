﻿using AbstractTravelAgencyServiceDAL.BindingModel;
using AbstractTravelAgencyServiceDAL.Interfaces;
using System.Web.Mvc;

namespace AbstractTravelAgencyViewWeb.Controllers
{
    public class PutCityController : Controller
    {
        private IConditionService conditionService = Globals.ConditionService;
        private ICityService cityService = Globals.CityService;
        private IMainService mainService = Globals.MainService;

        public ActionResult Index()
        {
            var conditions = new SelectList(conditionService.GetList(), "ConditionId", "ConditionName");
            ViewBag.Conditions = conditions;

            var cities = new SelectList(cityService.GetList(), "CityId", "CityName");
            ViewBag.Cities = cities;
            return View();
        }

        [HttpPost]
        public ActionResult PutCityPost()
        {
            mainService.PutConditionOnCity(new CityConditionBindingModel
            {
                ConditionId = int.Parse(Request["ConditionId"]),
                CityId = int.Parse(Request["CityId"]),
                Amount = int.Parse(Request["Amount"])
            });
            return RedirectToAction("List", "Cities");
        }
    }
}