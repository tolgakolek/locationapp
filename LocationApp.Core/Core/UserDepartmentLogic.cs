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
using LocationApp.Core.Helper;

namespace LocationApp.Core.Core
{
    public class UserDepartmenLogic
    {

        public ResultHelper AddUserDepartment(UserDepartmentDto userDepartmentDto)
        {
            try
            {
                if (IsThere(userDepartmentDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
                }
                userdepartment item = new userdepartment();
                item.UserID = userDepartmentDto.UserID;
                item.UserDepartmentID = userDepartmentDto.UserDepartmentID;
                item.DepartmentID = userDepartmentDto.DepartmentID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<userdepartment>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserDepartmentID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.IsThereItem);
            }
        }
        public ResultHelper SetUserDepartment(UserDepartmentDto userDepartmentDto)
        {
            try
            {
                userdepartment item = new userdepartment();
                item.UserID = userDepartmentDto.UserID;
                item.UserDepartmentID = userDepartmentDto.UserDepartmentID;
                item.DepartmentID = userDepartmentDto.DepartmentID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<userdepartment>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserDepartmentID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userDepartmentDto.UserID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUserDepartment(int UserDepartmentID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedUserDepartment = unitofWork.GetRepository<userdepartment>().GetById(x => x.UserDepartmentID == UserDepartmentID);
                    unitofWork.GetRepository<userdepartment>().Delete(selectedUserDepartment);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selectedUserDepartment.UserDepartmentID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, UserDepartmentID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserDepartmentDto GetUserDepartment(int UserDepartmentID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    userdepartment item = new userdepartment();
                    item = unitofWork.GetRepository<userdepartment>().GetById(x => x.UserDepartmentID == UserDepartmentID);
                    UserDepartmentDto userDepartmentDto = new UserDepartmentDto();
                    item.UserID = userDepartmentDto.UserID;
                    item.UserDepartmentID = userDepartmentDto.UserDepartmentID;
                    item.DepartmentID = userDepartmentDto.DepartmentID;

                    return userDepartmentDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<UserDepartmentDto> GetAllUserDepartment()
        {
            try
            {
                List<UserDepartmentDto> list = new List<UserDepartmentDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<userdepartment> collection = unitofWork.GetRepository<userdepartment>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new UserDepartmentDto { UserDepartmentID = item.UserDepartmentID, UserID = (int)item.UserID, DepartmentID = (int)item.DepartmentID });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserDepartmentDto>();
            }
        }
        public bool IsThere(UserDepartmentDto userDepartmentDto)
        {
            int userID = userDepartmentDto.UserID;
            int depID = userDepartmentDto.DepartmentID;
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<userdepartment>().GetById(x => x.DepartmentID == depID && x.UserID == userID);
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
    }
}
