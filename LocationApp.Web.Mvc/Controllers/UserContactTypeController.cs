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
    public class UserContactTypeController : BaseController
    {
        #region Services
        LocationApp.Service.Services.UserContactTypeService userContactTypeService = new Service.Services.UserContactTypeService();
        LocationApp.Service.Services.UserContactService userContactService = new Service.Services.UserContactService();
        LocationApp.Service.Services.UserService userService = new Service.Services.UserService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserContactTypeDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userContactTypeService.AddUserContactType(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<UserContactTypeDto>(userContactTypeService.GetUserContactType(id.Value));
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
        public ActionResult Edit(UserContactTypeDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userContactTypeService.SetUserContactType(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<UserContactTypeDto>>(userContactTypeService.GetAllUserContactType()));
        }

    }
}