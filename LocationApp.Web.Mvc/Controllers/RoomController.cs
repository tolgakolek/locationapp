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
    public class RoomController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.RoomService roomService = new Service.Services.RoomService();
        readonly LocationApp.Service.Services.BuildService buildService = new Service.Services.BuildService();
        readonly LocationApp.Service.Services.BlockService blockService = new Service.Services.BlockService();
        readonly LocationApp.Service.Services.DepartmentService department = new Service.Services.DepartmentService();
        readonly LocationApp.Service.Services.DepartmentRoomService departmentRoomService = new Service.Services.DepartmentRoomService();
        readonly LocationApp.Service.Services.FloorService floorService = new Service.Services.FloorService();
        readonly LocationApp.Service.Services.RoomTypeService roomTypeService = new Service.Services.RoomTypeService();
        #endregion

        [HttpGet]
        public ActionResult Create()
        {
            GetAllDropdowns();
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoomDto roomDto, int DepartmentID, HttpPostedFileBase mapFile)
        {
            if (mapFile.ContentLength > 0)
            {
                string _FileName = roomDto.Name + "_" + Path.GetFileName(mapFile.FileName);
                string _path = Path.Combine(Server.MapPath("~/Maps/Room"), _FileName);
                mapFile.SaveAs(_path);
                roomDto.Map = _FileName;
            }
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(roomService.AddRoom(roomDto));
            if (result.Result)
            {
                ResultHelper resultC = JsonConvert.DeserializeObject<ResultHelper>(departmentRoomService.AddDepartmentRoom(new DepartmentRoomDto
                {
                    DepartmentRoomID = 0,
                    DepartmentID = DepartmentID,
                    RoomID = result.ResultSet,
                    Other = "",
                }));
                ViewBag.Message = Helper.GetResultMessage(resultC.Result, result.ResultDescription);
            }
            else
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);

            GetAllDropdowns();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var item = JsonConvert.DeserializeObject<RoomDto>(roomService.GetRoom(id.Value));
                if (item.RoomID != 0)
                {
                    GetAllDropdowns();
                }
                else
                {
                    return RedirectToActionPermanent("NotFound", "Error");
                }
                return View(item);
            }
            catch (Exception)
            {
                return RedirectToActionPermanent("NotFound", "Error");
            }
        }
        [HttpPost]
        public ActionResult Edit(RoomDto roomDto, int DepartmentID, int DepartmentRoomID, HttpPostedFileBase mapFile)
        {
            if (mapFile != null)
            {
                if (mapFile.ContentLength > 0)
                {
                    string _FileName = roomDto.Name + "_" + Path.GetFileName(mapFile.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Maps/Room"), _FileName);
                    mapFile.SaveAs(_path);
                    roomDto.Map = _FileName;
                }
            }
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(roomService.SetRoom(roomDto));
            if (result.Result)
            {
                ResultHelper resultC = JsonConvert.DeserializeObject<ResultHelper>(departmentRoomService.SetDepartmentRoom(new DepartmentRoomDto
                {
                    DepartmentRoomID = DepartmentRoomID,
                    DepartmentID = DepartmentID,
                    RoomID = result.ResultSet,
                    Other =null,
                }));
                ViewBag.Message = Helper.GetResultMessage(resultC.Result, result.ResultDescription);
            }
            else
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);

            GetAllDropdowns();
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<RoomDto>>(roomService.GetAllRoom()));
        }
        [HttpGet]
        public JsonResult GetFloorByBlockID(int blockID)
        {
            var data = JsonConvert.DeserializeObject<List<FloorDto>>(floorService.GetAllFloorByBlockID(blockID));
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetFloorByBuildID(int buildID)
        {
            var data = JsonConvert.DeserializeObject<List<SubUnitDto>>(floorService.GetAllFloorByBuildID(buildID));
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            ResultHelper result;
            var selectedRoom = JsonConvert.DeserializeObject<RoomDto>(roomService.GetRoom(Id));
            result = JsonConvert.DeserializeObject<ResultHelper>(departmentRoomService.DelDepartmentRoom(selectedRoom.DepartmentRoomDto.DepartmentRoomID));
            if (result.Result)
            {
                result = JsonConvert.DeserializeObject<ResultHelper>(roomService.DelRoom(Id));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region Dropdownlist
        void GetAllDropdowns()
        {
            GetBuilds();
            GetBlocks();
            GetRoomTypes();
            GetFloors();
            GetDepartments();
        }
        void GetBuilds()
        {
            var list = JsonConvert.DeserializeObject<List<BuildDto>>(buildService.GetAllBuild());
            list.Insert(0, new BuildDto { BuildID = 0, Name = "Seçiniz" });
            ViewBag.Builds = list;
        }
        void GetBlocks()
        {
            var list = JsonConvert.DeserializeObject<List<BlockDto>>(blockService.GetAllBlock());
            list.Insert(0, new BlockDto { BlockID = 0, Name = "Seçiniz" });
            ViewBag.Blocks = list;
        }
        void GetRoomTypes()
        {
            var list = JsonConvert.DeserializeObject<List<RoomTypeDto>>(roomTypeService.GetAllRoomType());
            list.Insert(0, new RoomTypeDto { RoomTypeID = 0, Name = "Seçiniz" });
            ViewBag.RoomTypes = list;
        }
        void GetFloors()
        {
            var list = JsonConvert.DeserializeObject<List<FloorDto>>(floorService.GetAllFloor());
            list.Insert(0, new FloorDto { FloorID = 0, Name = "Seçiniz" });
            ViewBag.Floors = list;
        }
        void GetDepartments()
        {
            var list = JsonConvert.DeserializeObject<List<DepartmentDto>>(department.GetAllDepartment());
            list.Insert(0, new DepartmentDto { DepartmentID = 0, Name = "Seçiniz" });
            ViewBag.Departments = list;
        }
        #endregion
    }
}