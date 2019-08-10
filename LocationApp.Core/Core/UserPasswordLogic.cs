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
    public class UserPasswordLogic
    {

        public ResultHelper AddUserPassword(UserPasswordDto userPasswordDto)
        {
            try
            {
                if (IsThere(userPasswordDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.SuccessMessage);
                }
                userpassword item = new userpassword();
                item.Password = userPasswordDto.Password;
                item.UserID = userPasswordDto.UserID;
                item.UserPasswordID = userPasswordDto.UserPasswordID;
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<userpassword>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserPasswordID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserPassword(UserPasswordDto userPasswordDto)
        {
            try
            {
                userpassword item = new userpassword();
                item.Password = userPasswordDto.Password;
                item.UserID = userPasswordDto.UserID;
                item.UserPasswordID = userPasswordDto.UserPasswordID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<userpassword>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserPasswordID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userPasswordDto.UserPasswordID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUserPassword(int UserPasswordID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedUserPassword = unitofWork.GetRepository<userpassword>().GetById(x => x.UserPasswordID == UserPasswordID);
                    unitofWork.GetRepository<userpassword>().Delete(selectedUserPassword);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selectedUserPassword.UserPasswordID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, UserPasswordID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserPasswordDto GetUserPassword(int userId)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {

                    var item = unitofWork.GetRepository<userpassword>().GetById(x => x.UserID == userId);
                    UserPasswordDto userPasswordDto = new UserPasswordDto();
                    userPasswordDto.UserID = item.UserID.Value;
                    userPasswordDto.UserPasswordID = item.UserPasswordID;

                    return userPasswordDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool IsThere(UserPasswordDto userPasswordDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<userpassword>().GetById(x => x.UserPasswordID == userPasswordDto.UserPasswordID && x.Password == userPasswordDto.Password && x.UserID == userPasswordDto.UserID);
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
