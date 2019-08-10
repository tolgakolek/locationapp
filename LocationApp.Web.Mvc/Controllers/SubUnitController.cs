using LocationApp.Core.Helper;
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
    public class SubUnitController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.SubUnitService subUnitService = new Service.Services.SubUnitService();
        readonly LocationApp.Service.Services.MainUnitService mainUnitService = new Service.Services.MainUnitService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            GetMainUnits();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SubUnitDto model)
        {

            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(subUnitService.AddSubUnit(model));
            GetMainUnits(); GetMainUnits();
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<SubUnitDto>(subUnitService.GetSubUnit(id.Value));
                if (result != null)
                {
                    GetMainUnits();
                    return View(result);
                }
                else
                    return HttpNotFound();
            }
            catch (Exception)
            {
                return RedirectToActionPermanent("NotFound", "Error");
            }
        }
        [HttpPost]
        public ActionResult Edit(SubUnitDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(subUnitService.SetSubUnit(model));
            GetMainUnits();
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<SubUnitDto>>(subUnitService.GetAllSubUnit()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(subUnitService.DelSubUnit(Id)), JsonRequestBehavior.AllowGet);
        }
        #region Dropdownlist
        void GetMainUnits()
        {
            var list = JsonConvert.DeserializeObject<List<MainUnitDto>>(mainUnitService.GetAllMainUnit());
            list.Insert(0, new MainUnitDto { MainUnitID = 0, Name = "Seçiniz" });
            ViewBag.MainUnits = list;
        }
        #endregion
    }
}