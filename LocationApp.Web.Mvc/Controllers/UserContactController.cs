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
    public class UserContactController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.UserContactTypeService userContactTypeService = new Service.Services.UserContactTypeService();
        readonly LocationApp.Service.Services.UserService userService = new Service.Services.UserService();
        readonly LocationApp.Service.Services.UserContactService userContactService = new Service.Services.UserContactService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            GetUser(0);
            GetUserContactType(0);
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserContactDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userContactService.AddUserContact(model));
            GetUserContactType(model.UserContactTypeID);
            GetUser(model.UserID);
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<UserContactDto>(userContactService.GetUserContact(id.Value));
                if (result != null)
                {
                    GetUserContactType(result.UserContactTypeID);
                    GetUser(result.UserID);
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
        public ActionResult Edit(UserContactDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userContactService.SetUserContact(model));
            GetUserContactType(model.UserContactTypeID);
            GetUser(model.UserID);
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<UserContactDto>>(userContactService.GetAllUserContact()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(userContactService.DelUserContact(Id)), JsonRequestBehavior.AllowGet);
        }

        #region Dropdownlist
        void GetUser(int selectedValue)
        {
            var list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            list.Insert(0, new UserDto { UserID = 0, FullName = "Seçiniz" });
            ViewBag.Users = list;
        }
        void GetUserContactType(int selectedValue)
        {
            var list = JsonConvert.DeserializeObject<List<UserContactTypeDto>>(userContactTypeService.GetAllUserContactType());
            list.Insert(0, new UserContactTypeDto { UserContactTypeID = 0, TypeName = "Seçiniz" });
            ViewBag.UserContactType = list;
        }
        #endregion
    }
}