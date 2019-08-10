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
    public class UserPasswordController : BaseController
    {
        #region Services
        LocationApp.Service.Services.UserPasswordService userPasswordService = new Service.Services.UserPasswordService();
        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserPasswordDto model)
        {

            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userPasswordService.AddUserPassword(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<UserPasswordDto>(userPasswordService.GetUserPassword(id.Value));
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
        public ActionResult Edit(UserPasswordDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userPasswordService.SetUserPassword(model));
            if (result.Result)
                return View();
            {
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            }
            return View();
        }
        [HttpGet]
        public ActionResult List(int userPasswordID)
        {
            var item = JsonConvert.DeserializeObject<List<UserPasswordDto>>(userPasswordService.GetUserPassword(userPasswordID));
            return View(item);
        }
    }
}