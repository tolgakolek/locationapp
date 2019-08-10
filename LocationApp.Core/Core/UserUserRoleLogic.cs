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

    public class UserUserRoleLogic
    {
        public ResultHelper AddUserUserRole(UserUserRoleDto userUserRoleDto)
        {
            try
            {
                if (IsThere(userUserRoleDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.SuccessMessage);
                }
                useruserrole item = new useruserrole();
                item.UserUserRoleID = userUserRoleDto.UserUserRoleID;
                item.UserID = userUserRoleDto.UserID;
                item.UserRoleID = userUserRoleDto.UserRoleID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<useruserrole>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserUserRoleID, ResultHelper.SuccessMessage);

                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserUserRole(UserUserRoleDto userUserRoleDto)
        {
            try
            {
                useruserrole item = new useruserrole();
                item.UserUserRoleID = userUserRoleDto.UserUserRoleID;
                item.UserID = userUserRoleDto.UserID;
                item.UserRoleID = userUserRoleDto.UserRoleID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<useruserrole>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserUserRoleID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUserUserRole(int UserUserRoleID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedUserUserRole = unitofWork.GetRepository<useruserrole>().GetById(x => x.UserUserRoleID == UserUserRoleID);
                    unitofWork.GetRepository<useruserrole>().Delete(selectedUserUserRole);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selectedUserUserRole.UserUserRoleID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, UserUserRoleID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserUserRoleDto GetUserUserRole(int UserUserRoleID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    useruserrole item = new useruserrole();
                    item = unitofWork.GetRepository<useruserrole>().GetById(x => x.UserUserRoleID == UserUserRoleID);
                    UserUserRoleDto userUserRoleDto = new UserUserRoleDto();
                    item.UserUserRoleID = userUserRoleDto.UserUserRoleID;
                    item.UserID = userUserRoleDto.UserID;
                    item.UserRoleID = userUserRoleDto.UserRoleID;

                    return userUserRoleDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<UserUserRoleDto> GetAllUserUserRole()
        {
            try
            {
                List<UserUserRoleDto> list = new List<UserUserRoleDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<useruserrole> collection = unitofWork.GetRepository<useruserrole>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new UserUserRoleDto { UserID = (int)item.UserID, UserRoleID = (int)item.UserRoleID, UserUserRoleID = item.UserUserRoleID });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserUserRoleDto>();
            }
        }
        public bool IsThere(UserUserRoleDto userUserRoleDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<useruserrole>().GetById(x => x.UserUserRoleID == userUserRoleDto.UserUserRoleID && x.UserID == userUserRoleDto.UserID && x.UserRoleID == userUserRoleDto.UserRoleID);
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
