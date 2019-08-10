using LocationApp.Core.Helper;
using LocationApp.Data.Database;
using LocationApp.Data.Dto;
using LocationApp.Service.Services;
using LocationApp.Web.Mvc.Controllers;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Web.Controllers
{
    public class BuildController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.BuildService buildService = new Service.Services.BuildService();
        readonly LocationApp.Service.Services.CampusService campusService = new Service.Services.CampusService();
        readonly LocationApp.Service.Services.CampusService campusSiteService = new Service.Services.CampusService();
        readonly LocationApp.Service.Services.SiteService siteService = new Service.Services.SiteService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            GetCampus(); GetSites(0);
            return View();
        }
        [HttpPost]
        public ActionResult Create(BuildDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(buildService.AddBuild(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            GetCampus(); GetSites(model.CampusID);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<BuildDto>(buildService.GetBuild(id.Value));
                if (result != null)
                {
                    GetCampus(); GetSites(result.CampusID);
                    return View(result);
                }
                else
                    return RedirectToActionPermanent("NotFound", "Error");
            }
            catch (Exception)
            {
                return RedirectToActionPermanent("NotFound", "Error");
            }
        }
        [HttpPost]
        public ActionResult Edit(BuildDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(buildService.SetBuild(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            GetCampus(); GetSites(model.CampusID);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<BuildDto>>(buildService.GetAllBuild()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(buildService.DelBuild(Id)), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetSiteWithByCampusID(int campusID)
        {
            return Json(JsonConvert.DeserializeObject<List<SiteDto>>(siteService.GetAllSiteWithCampus(campusID)), JsonRequestBehavior.AllowGet);
        }

        #region Dropdownlist
        void GetSites(int campusID)
        {
            var siteList = JsonConvert.DeserializeObject<List<SiteDto>>(siteService.GetAllSiteWithCampus(campusID));
            siteList.Insert(0, new SiteDto { SiteID = 0, Name = "Seçiniz" });
            ViewBag.Sites = siteList;
        }
        void GetCampus()
        {
            var campusList = JsonConvert.DeserializeObject<List<CampusDto>>(campusService.GetAllCampus());
            campusList.Insert(0, new CampusDto { CampusID = 0, Name = "Seçiniz" });
            ViewBag.Campus = campusList;
        }
        #endregion
    }
}