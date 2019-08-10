using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using System.Net;
using LocationApp.Data.Database;
using LocationApp.Core.Helper;

namespace LocationApp.Core.Core
{
    public class UserRoleLogic
    {
        public ResultHelper AddUserRole(UserRoleDto userRoleDto)
        {
            try
            {
                if (IsThere(userRoleDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.IsThereItem);
                }
                userrole item = new userrole();
                item.UserRoleID = userRoleDto.UserRoleID;
                item.UserRoleName = userRoleDto.UserRoleName;
                item.UserRoleDescription = userRoleDto.UserRoleDescription;
                item.Active = userRoleDto.Active;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<userrole>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserRoleID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserRole(UserRoleDto userRoleDto)
        {
            try
            {
                userrole item = new userrole();
                item.UserRoleID = userRoleDto.UserRoleID;
                item.UserRoleName = userRoleDto.UserRoleName;
                item.UserRoleDescription = userRoleDto.UserRoleDescription;
                item.Active = userRoleDto.Active;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<userrole>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserRoleID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userRoleDto.UserRoleID, ResultHelper.UnSuccessMessage);
            }
        }
        public UserRoleDto GetUserRole(int userRoleID)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    userrole item = new userrole();
                    item = unitOfWork.GetRepository<userrole>().GetById(x => x.UserRoleID == userRoleID);
                    UserRoleDto userRoleDto = new UserRoleDto();
                    userRoleDto.UserRoleID = item.UserRoleID;
                    userRoleDto.UserRoleName = item.UserRoleName;
                    userRoleDto.UserRoleDescription = item.UserRoleDescription;
                    userRoleDto.Active = Convert.ToBoolean(item.Active);

                    return userRoleDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ResultHelper DelUserRole(int userRoleID)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var selectedUserRoleID = unitOfWork.GetRepository<userrole>().GetById(x => x.UserRoleID == userRoleID);
                    unitOfWork.GetRepository<userrole>().Delete(selectedUserRoleID);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, selectedUserRoleID.UserRoleID, ResultHelper.SuccessMessage);

                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, userRoleID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public List<UserRoleDto> GetAllUserRole()
        {
            try
            {
                List<UserRoleDto> list = new List<UserRoleDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<userrole> collection = unitofWork.GetRepository<userrole>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new UserRoleDto { UserRoleID = item.UserRoleID, UserRoleName = item.UserRoleName, UserRoleDescription = item.UserRoleDescription, Active = (bool)item.Active });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserRoleDto>();
            }
        }
        public bool IsThere(UserRoleDto userRoleDto)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var item = unitofWork.GetRepository<userrole>().GetById(x => x.UserRoleName == userRoleDto.UserRoleName);
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
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
