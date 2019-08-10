using LocationApp.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApp.Data;
using System.ServiceModel.Web;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using System.Net;
using LocationApp.Core.Enum;
using LocationApp.Core.Helper;

namespace LocationApp.Core.Core
{
    public class UserLogic
    {
        public ResultHelper AddUser(UserDto userDto)
        {
            try
            {
                if (IsThere(userDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
                }
                user item = new user();
                item.UserID = userDto.UserID;
                item.Name = userDto.Name;
                item.SurName = userDto.SurName;
                item.Gender = userDto.Gender;
                item.NationID = userDto.NationID;
                item.UserTitleID = userDto.UserTitleID;
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<user>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, userDto.UserID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUser(UserDto userDto)
        {
            try
            {
                user item = new user();
                item.UserID = userDto.UserID;
                item.Name = userDto.Name;
                item.SurName = userDto.SurName;
                item.Gender = userDto.Gender;
                item.NationID = userDto.NationID;
                item.UserTitleID = userDto.UserTitleID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<user>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userDto.UserID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUser(int UserID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var uc = unitofWork.GetRepository<usercontact>().GetById(x => x.UserID == UserID);
                    var ur = unitofWork.GetRepository<useruserrole>().GetById(x => x.UserID == UserID);
                    var ud = unitofWork.GetRepository<userdepartment>().GetById(x => x.UserID == UserID);
                    var up = unitofWork.GetRepository<userpassword>().GetById(x => x.UserID == UserID);
                    var user = unitofWork.GetRepository<user>().GetById(x => x.UserID == UserID);

                    unitofWork.GetRepository<usercontact>().Delete(uc);
                    unitofWork.GetRepository<useruserrole>().Delete(ur);
                    unitofWork.GetRepository<userdepartment>().Delete(ud);
                    unitofWork.GetRepository<userpassword>().Delete(up);
                    unitofWork.GetRepository<user>().Delete(user);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, user.UserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, UserID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserDto GetUser(int UserID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    user item = new user();
                    item = unitofWork.GetRepository<user>().GetById(x => x.UserID == UserID);
                    UserDto userDto = new UserDto();
                    userDto.UserID = item.UserID;
                    userDto.Name = item.Name;
                    userDto.SurName = item.SurName;
                    userDto.Gender = item.Gender;
                    userDto.NationID = item.NationID;
                    userDto.UserTitleID = item.UserTitleID.Value;
                    userDto.Email = unitofWork.GetRepository<usercontact>().GetById(x =>
                        x.UserID == UserID && x.UserContactTypeID == (int)Enums.ContacType.Email).Contact;
                    userDto.Password = unitofWork.GetRepository<userpassword>().GetById(x => x.UserID == UserID)
                        .Password;
                    userDto.UserPasswordID = unitofWork.GetRepository<userpassword>().GetById(x => x.UserID == UserID)
                        .UserPasswordID;
                    userDto.DepartmentID = unitofWork.GetRepository<userdepartment>().GetById(x => x.UserID == UserID).DepartmentID.Value;
                    userDto.UserRoleID = unitofWork.GetRepository<useruserrole>().GetById(x => x.UserID == UserID).UserRoleID.Value;
                    return userDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<UserDto> GetAllUser()
        {
            try
            {
                List<UserDto> list = new List<UserDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<user> collection = unitofWork.GetRepository<user>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        UserDto user = new UserDto();
                        user.UserID = item.UserID;
                        user.Name = item.Name;
                        user.SurName = item.SurName;
                        user.FullName = item.Name + " " + item.SurName;
                        user.Gender = item.Gender;
                        user.NationID = item.NationID;
                        user.UserTitleID = (int)item.UserTitleID;

                        var userTitle = unitofWork.GetRepository<usertitle>().GetById(model => model.UserTitleID == item.UserTitleID);
                        UserTitleDto userTitleDto = new UserTitleDto();
                        userTitleDto.UserTitleId = item.UserTitleID.Value;
                        userTitleDto.TitleName = userTitle.TitleName;
                        user.UserTitleDto = userTitleDto;

                        var depUser = unitofWork.GetRepository<userdepartment>().GetById(model => model.UserID == user.UserID);
                        UserDepartmentDto userDepartmentDto = new UserDepartmentDto();
                        userDepartmentDto.UserDepartmentID = depUser.DepartmentID.Value;
                        userDepartmentDto.UserID = item.UserID;
                        userDepartmentDto.UserDepartmentID = depUser.UserDepartmentID;
                        userDepartmentDto.UserDepartmentID = depUser.DepartmentID.Value;
                        user.UserDepartmentDto = userDepartmentDto;

                        var department = unitofWork.GetRepository<department>().GetById(model => model.DepartmentID == depUser.DepartmentID);
                        DepartmentDto departmentDto = new DepartmentDto();
                        departmentDto.DepartmentID = department.DepartmentID;
                        departmentDto.Name = department.Name;
                        user.DepartmentDto = departmentDto;

                        var password = unitofWork.GetRepository<userpassword>().GetById(x => x.UserID == user.UserID);
                        UserPasswordDto userPasswordDto = new UserPasswordDto();
                        userPasswordDto.UserPasswordID = password.UserPasswordID;
                        userPasswordDto.Password = password.Password;
                        user.UserPasswordDto = userPasswordDto;
                        list.Add(user);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserDto>();
            }
        }
        public bool IsThere(UserDto userDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<user>().GetById(x => x.UserID == userDto.UserID && x.Name == userDto.Name && x.SurName == userDto.SurName && x.Gender == userDto.Gender && x.NationID == userDto.NationID && x.UserTitleID == userDto.UserTitleID);
                if (item != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public object IsLogin(string contact, string password)
        {
            try
            {

                List<UserDto> list = new List<UserDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var query = (from us in unitofWork.GetRepository<user>().Select(null, null)
                                 join uc in unitofWork.GetRepository<usercontact>().Select(null, null) on us.UserID equals uc.UserID
                                 join up in unitofWork.GetRepository<userpassword>().Select(null, null) on us.UserID equals up.UserID
                                 where contact == uc.Contact && password == up.Password
                                 select new
                                 {
                                     UserID = us.UserID,
                                     Name = us.Name,
                                     SurName = us.SurName,
                                     Email = contact,
                                     UserContactID = uc.UserContactID,
                                     UserPasswordID = up.UserPasswordID,
                                     UserContact = uc.Contact,
                                     UserPassword = up.Password
                                 }).FirstOrDefault();
                    return query;
                }
            }
            catch
            {
                return null;
            }
        }
        public List<UserDto> GetAllUserDepartments()
        {
            try
            {
                List<UserDto> list = new List<UserDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var query = (from ud in unitofWork.GetRepository<userdepartment>().Select(null, null)
                                 join u in unitofWork.GetRepository<user>().Select(null, null) on ud.UserID equals u.UserID
                                 join d in unitofWork.GetRepository<department>().Select(null, null) on ud.DepartmentID equals d.DepartmentID
                                 select new
                                 {
                                     UserID = u.UserID,
                                     Name = u.Name,
                                     SurName = u.SurName,
                                     DepID = d.DepartmentID,
                                     UDepID = ud.UserDepartmentID,
                                     DepName = d.Name,
                                     NationID = u.NationID
                                 });
                    foreach (var item in query)
                    {
                        UserDto user = new UserDto();
                        user.Name = item.Name;
                        user.SurName = item.SurName;
                        user.UserID = item.UserID;
                        user.UserDepartmentID = item.UDepID;
                        user.DepartmentID = item.DepID;
                        user.DepartmentDto = new DepartmentDto();
                        user.DepartmentDto.Name = item.DepName;
                        user.NationID = item.NationID;
                        list.Add(user);
                    }
                    return list;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}

