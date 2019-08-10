using LocationApp.Core.Helper;
using LocationApp.Data.Dto;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Web.Mvc.Controllers
{
    public class DeviceController : BaseController
    {
        LocationApp.Service.Services.DeviceService deviceService = new Service.Services.DeviceService();
        LocationApp.Service.Services.DeviceTypeService deviceTypeService = new Service.Services.DeviceTypeService();
        LocationApp.Service.Services.UserService userService = new Service.Services.UserService();
        LocationApp.Service.Services.RoomService roomService = new Service.Services.RoomService();
        LocationApp.Service.Services.DeviceRoomService deviceRoomService = new Service.Services.DeviceRoomService();
        LocationApp.Service.Services.DeviceUserService deviceUserService = new Service.Services.DeviceUserService();


        [HttpGet]
        public ActionResult Create()
        {
            GetDeviceType(); GetUser(); GetRoom(); GetDevices(); 
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeviceDto model)
        {
            GetDeviceType(); GetUser(); GetRoom(); GetDevices();

            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceService.AddDevice(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                GetDeviceType(); GetUser(); GetRoom(); GetDevices();

                var result = JsonConvert.DeserializeObject<DeviceDto>(deviceService.GetDevice(id.Value));
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
        public ActionResult Edit(DeviceDto model)
        {
            GetDeviceType(); GetUser(); GetRoom(); GetDevices();
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceService.SetDevice(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            var item = JsonConvert.DeserializeObject<List<DeviceDto>>(deviceService.GetAllDevice());
            return View(item);
        }
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(deviceService.DelDevice(Id)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddDeviceType(string name)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>
            (deviceTypeService.AddDeviceType(new DeviceTypeDto() { Name = name }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddDeviceUser(int userID, int DeviceID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceUserService.AddDeviceUser(new DeviceUserDto { DeviceID = DeviceID, UserID = userID }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddDeviceRoom(int RoomID, int DeviceID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceRoomService.AddDeviceRoom(new DeviceRoomDto { DeviceID = DeviceID, RoomID = RoomID }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetUsers()
        {
            var data = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetRooms()
        {
            var data = JsonConvert.DeserializeObject<List<RoomDto>>(roomService.GetAllRoom());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #region dropdown
        void GetDeviceType()
        {
            var list = JsonConvert.DeserializeObject<List<DeviceTypeDto>>(deviceTypeService.GetAllDeviceType());
            list.Insert(0, new DeviceTypeDto { DeviceTypeID = 0, Name = "Seçiniz" });
            ViewBag.DeviceTypes = list;

        }
        public void GetUser()
        {
            var list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            list.Insert(0, new UserDto { UserID = 0, Name = "Seçiniz" });
            ViewBag.Users = list;
        }
        public void GetRoom()
        {
            var list = JsonConvert.DeserializeObject<List<RoomDto>>(roomService.GetAllRoom());
            list.Insert(0, new RoomDto { RoomID = 0, Name = "Seçiniz" });
            ViewBag.Rooms = list;
        }
        void GetDevices()
        {
            var list = JsonConvert.DeserializeObject<List<DeviceDto>>(deviceService.GetAllDevice());
            list.Insert(0, new DeviceDto { DeviceID = 0, Name = "Seçiniz" });
            ViewBag.Devices = list;
        }
        #endregion

    }
}