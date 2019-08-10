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
    public class MainUnitController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.MainUnitService mainUnitService = new Service.Services.MainUnitService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MainUnitDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(mainUnitService.AddMainUnit(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<MainUnitDto>(mainUnitService.GetMainUnit(id.Value));
                if (result != null)
                    return View(result);
                else
                    return RedirectToActionPermanent("NotFound", "Error");
            }
            catch (Exception)
            {
                return RedirectToActionPermanent("NotFound", "Error");
            }
        }
        [HttpPost]
        public ActionResult Edit(MainUnitDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(mainUnitService.SetMainUnit(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<MainUnitDto>>(mainUnitService.GetAllMainUnit()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(mainUnitService.DelMainUnit(Id)), JsonRequestBehavior.AllowGet);
        }
    }
}