using LocationApp.Core.Helper;
using LocationApp.Data.Database;
using LocationApp.Data.Dto;
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
    public class SiteController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.SiteService siteService = new Service.Services.SiteService();
        readonly LocationApp.Service.Services.CampusSiteService campusSiteService = new Service.Services.CampusSiteService();
        readonly LocationApp.Service.Services.CampusService campusService = new Service.Services.CampusService();
        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            GetCampusList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SiteDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(siteService.AddSite(model));
            if (result.Result)
            {
                ResultHelper resultC = JsonConvert.DeserializeObject<ResultHelper>(campusSiteService.AddCampusSite(new Data.Dto.CampusSiteDto
                {
                    CampusSiteID = 0,
                    CampusID = model.CampusID,
                    SiteID = result.ResultSet,
                    Other = null
                }));
                ViewBag.Message = Helper.GetResultMessage(resultC.Result, result.ResultDescription);
            }
            else
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);

            GetCampusList();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            GetCampusList();
            try
            {
                var result = JsonConvert.DeserializeObject<SiteDto>(siteService.GetSite(id.Value));
                if (result != null)
                {
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
        public ActionResult Edit(int CampusSiteID, SiteDto model)
        {
            GetCampusList();
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(siteService.SetSite(model));
            if (result.Result)
            {
                ResultHelper resultC = JsonConvert.DeserializeObject<ResultHelper>
                (campusSiteService.SetCampusSite(new Data.Dto.CampusSiteDto
                {
                    CampusID = model.CampusID,
                    CampusSiteID = CampusSiteID,
                    Other = null,
                    SiteID = result.ResultSet
                }));
                ViewBag.Message = Helper.GetResultMessage(resultC.Result, result.ResultDescription);
            }
            else
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            model.CampusSiteDto.CampusSiteID = model.CampusSiteID;
            return View(model);
        }
        [HttpGet]
        public ActionResult List(int? id)
        {
            GetCampus();
            if (id != null)
            {
                ViewBag.SelectedCampusID = id.Value;
                return View(JsonConvert.DeserializeObject<List<SiteDto>>(siteService.GetAllSiteWithCampus(id.Value)));
            }
            else
            {
                ViewBag.SelectedCampusID = 0;
                return View(JsonConvert.DeserializeObject<List<SiteDto>>(siteService.GetAllSite()));
            }
        }

        [HttpPost]
        public JsonResult Remove(int Id)
        {
            var site = JsonConvert.DeserializeObject<SiteDto>(siteService.GetSite(Id));
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(campusSiteService.DelCampusSite(site.CampusSiteID));
            if (result.Result)
            {
                result = JsonConvert.DeserializeObject<ResultHelper>(siteService.DelSite(Id));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        void GetCampusList()
        {
            var list = JsonConvert.DeserializeObject<List<CampusDto>>(campusService.GetAllCampus());
            list.Insert(0, new CampusDto { CampusID = 0, Name = "Seçiniz" });
            ViewBag.Campus = list;
        }
        void GetCampus()
        {
            var list = JsonConvert.DeserializeObject<List<CampusDto>>(campusService.GetAllCampus());
            list.Insert(0, new CampusDto { CampusID = 0, Name = "Seçiniz" });
            ViewBag.Campus = list;
        }
    }
}