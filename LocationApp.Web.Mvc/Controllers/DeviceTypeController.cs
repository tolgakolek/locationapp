using LocationApp.Core.Helper;
using LocationApp.Data.Database;
using LocationApp.Data.Dto;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace LocationApp.Web.Mvc.Controllers
{
    public class DeviceTypeController : BaseController
    {
        #region
        LocationApp.Service.Services.DeviceTypeService deviceTypeService = new Service.Services.DeviceTypeService();
        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeviceTypeDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceTypeService.AddDeviceType(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<DeviceTypeDto>(deviceTypeService.GetDeviceType(id.Value));
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
        public ActionResult Edit(DeviceTypeDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceTypeService.SetDeviceType(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<DeviceTypeDto>>(deviceTypeService.GetAllDeviceType()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(deviceTypeService.DelDeviceType(Id)), JsonRequestBehavior.AllowGet);
        }
    }
}