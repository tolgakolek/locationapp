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
    public class BlockController : BaseController
    {
        #region Services
        LocationApp.Service.Services.BlockService blockService = new Service.Services.BlockService();
        LocationApp.Service.Services.BuildService buildService = new Service.Services.BuildService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            GetBuilds();
            return View();
        }
        [HttpPost]
        public ActionResult Create(BlockDto model)
        {
            GetBuilds();
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(blockService.AddBlock(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<BlockDto>(blockService.GetBlock(id.Value));
                if (result != null)
                {
                    GetBuilds();
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
        public ActionResult Edit(BlockDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(blockService.SetBlock(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            GetBuilds();
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            var item = JsonConvert.DeserializeObject<List<BlockDto>>(blockService.GetAllBlock());
            return View(item);
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(blockService.DeleteBlock(Id)), JsonRequestBehavior.AllowGet);
        }

        #region Dropdownlist
        void GetBuilds()
        {
            var list = JsonConvert.DeserializeObject<List<BuildDto>>(buildService.GetAllBuild());
            list.Insert(0, new BuildDto { BuildID = 0, Name = "Seçiniz" });
            ViewBag.Builds = list;
        }
        #endregion
    }
}