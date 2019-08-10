using LocationApp.Core.Helper;
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
    public class UserRoleController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.UserRoleService userRoleService = new Service.Services.UserRoleService();
        #endregion
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<UserRoleDto>>(userRoleService.GetAllUserRole()));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserRoleDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userRoleService.AddUserRole(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<UserRoleDto>(userRoleService.GetUserRole(id.Value));
                if (result != null)
                    return View(result);
                else
                    return HttpNotFound();
            }
            catch (Exception)
            {
                return RedirectToActionPermanent("NotFound", "Error");
            }
        }
        [HttpPost]
        public ActionResult Edit(UserRoleDto model)
        {
            if (ModelState.IsValid)
            {
                ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>
                         (userRoleService.SetUserRole(model)
                         );
                if (result.Result)
                {
                    ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(userRoleService.DelUserRole(Id)), JsonRequestBehavior.AllowGet);
        }
    }
}