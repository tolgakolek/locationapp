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
    public class DeviceFloorController : BaseController
    {
        #region
        LocationApp.Service.Services.DeviceUserService deviceUserService = new Service.Services.DeviceUserService();
        LocationApp.Service.Services.DeviceTypeService deviceTypeService = new Service.Services.DeviceTypeService();
        LocationApp.Service.Services.DeviceService deviceService = new Service.Services.DeviceService();
        LocationApp.Service.Services.DeviceRoomService deviceRoomService = new Service.Services.DeviceRoomService();
        LocationApp.Service.Services.RoomService roomService = new Service.Services.RoomService();

        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeviceRoomDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceRoomService.AddDeviceRoom(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<DeviceRoomDto>(deviceRoomService.GetDeviceRoom(id.Value));
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
        public ActionResult Edit(DeviceRoomDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceRoomService.SetDeviceRoom(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            GetDevice();
            GetFloor();
            return View(JsonConvert.DeserializeObject<List<DeviceRoomDto>>(deviceRoomService.GetAllDeviceRoom()));
        }
        void GetFloor()
        {
            var list = JsonConvert.DeserializeObject<List<RoomDto>>(roomService.GetAllRoom());
            list.Insert(0, new RoomDto { RoomID = 0, Name = "Seçiniz" });
            ViewBag.Room = list;
        }
        void GetDevice()
        {
            var list = JsonConvert.DeserializeObject<List<DeviceDto>>(deviceService.GetAllDevice());
            list.Insert(0, new DeviceDto { DeviceID = 0, Name = "Seçiniz" });
            ViewBag.Device = list;
        }
        [HttpGet]
        public ActionResult AddFloor()
        {
            GetFloor();
            GetDevice();
            return View(JsonConvert.DeserializeObject<List<DeviceUserDto>>(deviceUserService.GetAllDeviceUser()));
        }
        [HttpPost]
        public JsonResult AddFloor(int RoomID, int DeviceID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceRoomService.AddDeviceRoom(new DeviceRoomDto { DeviceID = DeviceID, RoomID = RoomID }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}