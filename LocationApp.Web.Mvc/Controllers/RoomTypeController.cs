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
    public class RoomTypeController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.RoomTypeService roomTypeService = new Service.Services.RoomTypeService();
        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoomTypeDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(roomTypeService.AddRoomType(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<RoomTypeDto>(roomTypeService.GetRoomType(id.Value));
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
        public ActionResult Edit(RoomTypeDto roomTypeDto)
        {
            if (ModelState.IsValid)
            {
                ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(roomTypeService.SetRoomType(roomTypeDto));
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            }
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<RoomTypeDto>>(roomTypeService.GetAllRoomType()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(roomTypeService.DelRoomType(Id)), JsonRequestBehavior.AllowGet);
        }
    }
}