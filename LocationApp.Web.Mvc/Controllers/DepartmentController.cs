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
    public class DepartmentController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.SubUnitService subUnitService = new Service.Services.SubUnitService();
        readonly LocationApp.Service.Services.MainUnitService mainUnitService = new Service.Services.MainUnitService();
        readonly LocationApp.Service.Services.DepartmentService departmentService = new Service.Services.DepartmentService();
        readonly LocationApp.Service.Services.UserDepartmentService userDepartmentService = new Service.Services.UserDepartmentService();
        readonly LocationApp.Service.Services.DepartmentRoomService departmentRoomService = new Service.Services.DepartmentRoomService();
        readonly LocationApp.Service.Services.UserService userService = new Service.Services.UserService();
        #endregion
        [HttpGet]
        public ActionResult Create()
        {
            GetMainUnits(0); GetSubUnits(0);
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentDto model, int MainUnitID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(departmentService.AddDepartment(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            GetMainUnits(0); GetSubUnits(0);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<DepartmentDto>(departmentService.GetDepartment(id));
                if (result != null)
                {
                    GetMainUnits(result.SubUnitID); GetSubUnits(result.SubUnitID);
                    return View(result);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(DepartmentDto model, int MainUnitID,int SubUnitID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(departmentService.SetDepartment(model));
            GetMainUnits(MainUnitID); GetSubUnits(SubUnitID);
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<DepartmentDto>>(departmentService.GetAllDepartment()));
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(departmentService.DelDepartment(Id)), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            GetUsers();
            GetDepartments();
            return View(JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUserDepartments()));
        }
        [HttpPost]
        public JsonResult AddUser(int userID, int departmentID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userDepartmentService.AddUserDepartment(new UserDepartmentDto { DepartmentID = departmentID, UserID = userID }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetSubUnit(int mainUnitID)
        {
            var data = JsonConvert.DeserializeObject<List<SubUnitDto>>(subUnitService.GetAllSubUnitWithByMainUnitID(mainUnitID));
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #region Dropdownlist
        void GetMainUnits(int mainUnitID)
        {
            var list = JsonConvert.DeserializeObject<List<MainUnitDto>>(mainUnitService.GetAllMainUnit());
            list.Insert(0, new MainUnitDto { MainUnitID = 0, Name = "Seçiniz" });
            ViewBag.MainUnits = list;
            ViewBag.SelectedMainUnitID = mainUnitID;
        }
        void GetSubUnits(int subUnitID)
        {
            var list = JsonConvert.DeserializeObject<List<SubUnitDto>>(subUnitService.GetAllSubUnit());
            list.Insert(0, new SubUnitDto { SubUnitID = 0, Name = "Seçiniz" });
            ViewBag.SubUnits = list;
            ViewBag.SelectedMainUnitID = subUnitID;
        }
        void GetUsers()
        {
            var list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            list.Insert(0, new UserDto { UserID = 0, FullName = "Seçiniz" });
            ViewBag.Users = list;
        }
        void GetDepartments()
        {
            var list = JsonConvert.DeserializeObject<List<DepartmentDto>>(departmentService.GetAllDepartment());
            list.Insert(0, new DepartmentDto { DepartmentID = 0, Name = "Seçiniz" });
            ViewBag.Departments = list;
        }
        #endregion
    }
}