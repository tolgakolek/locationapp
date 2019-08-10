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
    public class UserController : BaseController
    {
        #region Services
        readonly LocationApp.Service.Services.UserTitleService userTitleService = new Service.Services.UserTitleService();
        readonly LocationApp.Service.Services.UserService userService = new Service.Services.UserService();
        readonly LocationApp.Service.Services.UserDepartmentService userDepartmentService = new LocationApp.Service.Services.UserDepartmentService();
        readonly LocationApp.Service.Services.DepartmentService departmentService = new Service.Services.DepartmentService();
        readonly LocationApp.Service.Services.UserContactService userContactService = new Service.Services.UserContactService();
        readonly LocationApp.Service.Services.UserContactTypeService userContactTypeService = new Service.Services.UserContactTypeService();
        readonly LocationApp.Service.Services.UserPasswordService userPasswordService = new Service.Services.UserPasswordService();
        readonly LocationApp.Service.Services.UserUserRoleService userUserRoleService = new Service.Services.UserUserRoleService();
        readonly LocationApp.Service.Services.UserRoleService userRoleService = new Service.Services.UserRoleService();
        readonly LocationApp.Service.Services.MainUnitService mainUnitService = new Service.Services.MainUnitService();
        readonly LocationApp.Service.Services.SubUnitService subUnitService = new Service.Services.SubUnitService();
        #endregion

        #region User
        [HttpGet]
        public ActionResult Create()
        {
            GetUserTitle(); GetRole(); GetDepartment(); GetMainUnits(); GetSubUnits();
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserDto model)
        {
            bool operation = true;
            var resultUser = JsonConvert.DeserializeObject<ResultHelper>(userService.AddUser(model));
            ViewBag.Message = Helper.GetResultMessage(resultUser.Result, resultUser.ResultDescription);
            if (resultUser.Result)
            {
                var resultDepartment = JsonConvert.DeserializeObject<ResultHelper>(userDepartmentService.AddUserDepartment
                    (new UserDepartmentDto { DepartmentID = model.UserDepartmentID, UserID = resultUser.ResultSet, UserDepartmentID = 0 }));
                if (resultDepartment.Result)
                {
                    var resultContact = JsonConvert.DeserializeObject<ResultHelper>(userContactService.AddUserContact(
                        new UserContactDto { UserContactID = 0, UserID = resultUser.ResultSet, UserContactTypeID = (int)Core.Enum.Enums.ContacType.Email, Contact = model.Email }));
                    if (resultContact.Result)
                    {
                        var resultPass = JsonConvert.DeserializeObject<ResultHelper>(userPasswordService.AddUserPassword(
                            new UserPasswordDto { UserPasswordID = 0, UserID = resultUser.ResultSet, Password = model.Password }));

                        if (resultPass.Result)
                        {
                            var resultRol = JsonConvert.DeserializeObject<ResultHelper>(userUserRoleService.AddUserUserRole(new UserUserRoleDto { UserID = resultUser.ResultSet, UserRoleID = model.UserRoleID, UserUserRoleID = 0 }));
                            if (resultRol.Result)
                                return RedirectToAction("Create");
                            else
                                operation = false;
                        }
                        else
                            operation = false;
                    }
                    else
                        operation = false;
                }
                else
                    operation = false;
            }
            else
                operation = false;
            if (!operation)
            {
                GetUserTitle(); GetRole(); GetDepartment();
                return View();
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var result = JsonConvert.DeserializeObject<UserDto>(userService.GetUser(id.Value));
            if (result != null)
            {
                GetDepartment(); GetUserTitle(); GetRole(); GetMainUnits(); GetSubUnits(); GetUserTitle();
                return View(result);
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(UserDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userService.SetUser(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            GetDepartment(); GetUserTitle(); GetRole(); GetMainUnits(); GetSubUnits(); GetUserTitle();
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser()));
        }
        [HttpGet]
        public ActionResult Password(int id)
        {
            var result = JsonConvert.DeserializeObject<UserPasswordDto>(userPasswordService.GetUserPassword(id));
            if (result != null)
            {
                return View(result);
            }
            else
            { return RedirectToActionPermanent("NotFound", "Error"); }

        }
        [HttpPost]
        public ActionResult Password(UserPasswordDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userPasswordService.SetUserPassword(model));
            if (result.Result)
            {
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
                return View();
            }
            else
            {
                ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            }
            return View();

        }
        [HttpGet]
        public ActionResult UserDepartments(int? id)
        {
            List<UserDto> list = new List<UserDto>();
            if (id != null)
            {
                list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUserDepartments());
                return View(list.Where(a => a.UserID == id.Value).ToList());
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUserDepartments());
                return View(list);
            }
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            var result = JsonConvert.DeserializeObject<ResultHelper>(userService.DelUser(Id));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Contact
        [HttpGet]
        public ActionResult CreateUserContact()
        {
            GetUsers(); GetUserContactTypes();
            return View(JsonConvert.DeserializeObject<List<UserContactDto>>(userContactService.GetAllUserContact()));
        }
        [HttpGet]
        public JsonResult AddUserContact(int userID, int userContactTypeID, string contact)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userContactService.AddUserContact(new UserContactDto { UserContactTypeID = userContactTypeID, UserID = userID, Contact = contact }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult RemoveUserContact(int Id)
        {
            return Json(JsonConvert.DeserializeObject<ResultHelper>(userContactService.DelUserContact(Id)), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddDepartment(int subUnitID, string name)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>
           (departmentService.AddDepartment(new DepartmentDto { SubUnitID = subUnitID, DepartmentID = 0, Name = name }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddUserTitle(string name)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>
            (userTitleService.AddUserTitle(new UserTitleDto() { TitleName = name }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Dropdownlist
        void GetUserTitle()
        {
            var list = JsonConvert.DeserializeObject<List<UserTitleDto>>(userTitleService.GetAllUserTitle());
            list.Insert(0, new UserTitleDto { UserTitleId = 0, TitleName = "Seçiniz" });
            ViewBag.UserTitle = list;
        }
        void GetDepartment()
        {
            var list = JsonConvert.DeserializeObject<List<DepartmentDto>>(departmentService.GetAllDepartment());
            list.Insert(0, new DepartmentDto { DepartmentID = 0, Name = "Seçiniz" });
            ViewBag.Departments = list;
        }
        void GetRole()
        {
            var list = JsonConvert.DeserializeObject<List<UserRoleDto>>(userRoleService.GetAllUserRole());
            list.Insert(0, new UserRoleDto { UserRoleID = 0, UserRoleName = "Seçiniz" });
            ViewBag.Roles = list;
        }
        void GetUsers()
        {
            var list = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            list.Insert(0, new UserDto { UserID = 0, FullName = "Seçiniz" });
            ViewBag.Users = list;
        }
        void GetUserContactTypes()
        {
            var list = JsonConvert.DeserializeObject<List<UserContactTypeDto>>(userContactTypeService.GetAllUserContactType());
            list.Insert(0, new UserContactTypeDto { UserContactTypeID = 0, TypeName = "Seçiniz" });
            ViewBag.UserContactTypes = list;
        }
        void GetMainUnits()
        {
            var list = JsonConvert.DeserializeObject<List<MainUnitDto>>(mainUnitService.GetAllMainUnit());
            list.Insert(0, new MainUnitDto { MainUnitID = 0, Name = "Seçiniz" });
            ViewBag.MainUnits = list;
        }
        void GetSubUnits()
        {
            var list = JsonConvert.DeserializeObject<List<SubUnitDto>>(subUnitService.GetAllSubUnit());
            list.Insert(0, new SubUnitDto { SubUnitID = 0, Name = "Seçiniz" });
            ViewBag.SubUnits = list;
        }
        #endregion
    }
}