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
    public class DeviceUserController : BaseController
    {
        #region
        LocationApp.Service.Services.DeviceUserService deviceUserService = new Service.Services.DeviceUserService();
        LocationApp.Service.Services.DeviceTypeService deviceTypeService = new Service.Services.DeviceTypeService();
        LocationApp.Service.Services.DeviceService deviceService = new Service.Services.DeviceService();
        readonly LocationApp.Service.Services.UserService userService = new Service.Services.UserService();

        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeviceUserDto model)
        {
            GetUsers();
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceUserService.AddDeviceUser(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<DeviceUserDto>(deviceUserService.GetDeviceUser(id.Value));
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
        public ActionResult Edit(DeviceUserDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceUserService.SetDeviceUser(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            GetUsers();
            GetDevice();
            return View(JsonConvert.DeserializeObject<List<DeviceUserDto>>(deviceUserService.GetAllDeviceUser()));
        }
        void GetUsers()
        {
            var list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            list.Insert(0, new UserDto { UserID = 0, FullName = "Seçiniz" });
            ViewBag.Users = list;
        }
        void GetDevice()
        {
            var list = JsonConvert.DeserializeObject<List<DeviceDto>>(deviceService.GetAllDevice());
            list.Insert(0, new DeviceDto { DeviceID = 0, Name = "Seçiniz" });
            ViewBag.Device = list;
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            GetUsers();
            GetDevice();
            return View(JsonConvert.DeserializeObject<List<DeviceUserDto>>(deviceUserService.GetAllDeviceUser()));
        }
        [HttpPost]
        public JsonResult AddUser(int userID, int DeviceID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(deviceUserService.AddDeviceUser(new DeviceUserDto { DeviceID = DeviceID, UserID = userID }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}