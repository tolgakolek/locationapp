using LocationApp.Data.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Web.Mvc.Controllers
{
    public class UserInfoController : Controller
    {
        readonly LocationApp.Service.Services.UserService userService = new Service.Services.UserService();
        readonly LocationApp.Service.Services.DeviceRoomService deviceRoomService = new Service.Services.DeviceRoomService();
        readonly LocationApp.Service.Services.DeviceUserService deviceUserService = new Service.Services.DeviceUserService();
        readonly LocationApp.Service.Services.DeviceService deviceService = new Service.Services.DeviceService();
        readonly LocationApp.Service.Services.DepartmentService departmentService = new Service.Services.DepartmentService();
        readonly LocationApp.Service.Services.UserDepartmentService userDepartmentService = new Service.Services.UserDepartmentService();
        readonly LocationApp.Service.Services.SenderRecieverDeviceService senderRecieverDeviceService = new Service.Services.SenderRecieverDeviceService();

        public ActionResult List()
        {
            GetUsers();
            return View();
        }

        [HttpGet]
        public JsonResult GetMobilWifi()
        {
            var data = JsonConvert.DeserializeObject<List<SenderRecieverDeviceMobilBeaconDto>>(senderRecieverDeviceService.GetMobilBeaconList());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetUser()
        {
            var data = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser()).Take(1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetUserDep()
        {
            var data = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUserDepartments());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetDateByBeetween(DateTime Start, DateTime End)
        {
            var data = JsonConvert.DeserializeObject<List<SenderRecieverDeviceRaspberryBeaconDto>>(senderRecieverDeviceService.GetDateNodemMcuBeacon(Start, End)).Take(250);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetUserInfo(int UserID)
        {
            var data = JsonConvert.DeserializeObject<List<DeviceUserDto>>(deviceUserService.GetAllDeviceUser());
            var item=data.Where(x => x.UserID == UserID);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetRoomInfo(int DeviceID)
        {
            var data = JsonConvert.DeserializeObject<List<DeviceRoomDto>>(deviceRoomService.GetAllDeviceRoom());
            var item = data.Where(x => x.DeviceID == DeviceID);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        void GetUsers()
        {
            var list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            list.Insert(0, new UserDto { UserID = 0, FullName = "Seçiniz" });
            ViewBag.Users = list;
        }

        // Personelin Bağlı Bulunduğu departmanlar getirilecek
    }
}