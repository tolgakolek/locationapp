using LocationApp.Core.Helper;
using LocationApp.Data.Database;
using LocationApp.Data.Dto;
using LocationApp.Web.Mvc.Controllers;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Web.Controllers
{
    public class FloorController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.FloorService floorService = new Service.Services.FloorService();
        readonly LocationApp.Service.Services.BuildService buildService = new Service.Services.BuildService();
        readonly LocationApp.Service.Services.BlockService blockService = new Service.Services.BlockService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            GetAllBuilds(); GetAllBlocks();
            return View();
        }
        [HttpPost]
        public ActionResult Create(int SelectBtype, FloorDto model, HttpPostedFileBase mapFile)
        {
            if (mapFile != null)
            {
                if (mapFile.ContentLength > 0)
                {
                    string _FileName = model.Name + "_" + Path.GetFileName(mapFile.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Maps/Floor"), _FileName);
                    mapFile.SaveAs(_path);
                    model.Map = _FileName;
                }
            }
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(floorService.AddFloor(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            GetAllBuilds(); GetAllBlocks();
            return View();
        }
        [HttpGet]
        public ActionResult Set(int id)
        {
            GetAllBuilds();
            GetAllBlocks();
            var result = JsonConvert.DeserializeObject<FloorDto>(floorService.GetFloor(id));
            if (result != null)
            {
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public ActionResult Set(FloorDto model, HttpPostedFileBase mapFile)
        {
            GetAllBuilds(); GetAllBlocks();
            if (mapFile != null)
            {
                if (mapFile.ContentLength > 0)
                {
                    string _FileName = model.Name + "_" + Path.GetFileName(mapFile.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Maps/Floor"), _FileName);
                    mapFile.SaveAs(_path);
                    model.Map = _FileName;
                }
            }
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(floorService.SetFloor(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
          
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<FloorDto>>(floorService.GetAllFloor()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(floorService.DelFloor(Id)), JsonRequestBehavior.AllowGet);
        }
        #region Dropdownlist
        void GetAllBuilds()
        {
            var list = JsonConvert.DeserializeObject<List<BuildDto>>(buildService.GetAllBuild());
            list.Insert(0, new BuildDto { BuildID = 0, Name = "Seçiniz" });
            ViewBag.Builds = list;
        }
        void GetAllBlocks()
        {
            var list = JsonConvert.DeserializeObject<List<BlockDto>>(blockService.GetAllBlock());
            list.Insert(0, new BlockDto { BlockID = 0, Name = "Seçiniz" });
            ViewBag.Blocks = list;
        }
        #endregion
    }
}