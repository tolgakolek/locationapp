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
    public class CampusController : BaseController
    {
        #region Services
        LocationApp.Service.Services.CampusService campusService = new Service.Services.CampusService();
        LocationApp.Service.Services.CampusSiteService campusSiteService = new Service.Services.CampusSiteService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CampusDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(campusService.AddCampus(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<CampusDto>(campusService.GetCampus(id.Value));
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
        public ActionResult Edit(CampusDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(campusService.SetCampus(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<CampusDto>>(campusService.GetAllCampus()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(campusService.DelCampus(Id)), JsonRequestBehavior.AllowGet);
        }
    }
}