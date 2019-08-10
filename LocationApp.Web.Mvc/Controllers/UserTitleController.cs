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
    public class UserTitleController : BaseController
    {
        #region Services
        LocationApp.Service.Services.UserTitleService userTitleService = new Service.Services.UserTitleService();
        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserTitleDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userTitleService.AddUserTitle(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<UserTitleDto>(userTitleService.GetUserTitle(id.Value));
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
        public ActionResult Edit(UserTitleDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userTitleService.SetUserTitle(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<UserTitleDto>>(userTitleService.GetAllUserTitle()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(userTitleService.DelUserTitle(Id)), JsonRequestBehavior.AllowGet);
        }
    }
}