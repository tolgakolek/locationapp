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
    public class UserLoginLogic
    {
        public ResultHelper AddUserLogin(UserLoginDto userLoginDto)
        {
            try
            {
                if (IsThere(userLoginDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.SuccessMessage);
                }
                userlogin item = new userlogin();
                item.UserLoginID = userLoginDto.UserLoginID;
                item.Password = userLoginDto.Password;
                item.IpAdress = userLoginDto.IpAdress;
                item.UserID = userLoginDto.UserID;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<userlogin>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserLoginID, ResultHelper.SuccessMessage);
                }

            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserLogin(UserLoginDto userLoginDto)
        {
            try
            {
                userlogin item = new userlogin();
                item.UserLoginID = userLoginDto.UserLoginID;
                item.Password = userLoginDto.Password;
                item.IpAdress = userLoginDto.IpAdress;
                item.UserID = userLoginDto.UserID;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<userlogin>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserLoginID, ResultHelper.SuccessMessage);
                }
            }
            catch
            {
                return new ResultHelper(false, userLoginDto.UserLoginID, ResultHelper.UnSuccessMessage);
            }
        }
        public UserLoginDto GetUserLogin(int userLoginID)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    userlogin item = new userlogin();
                    item = unitOfWork.GetRepository<userlogin>().GetById(x => x.UserLoginID == userLoginID);
                    UserLoginDto userLoginDto = new UserLoginDto();
                    userLoginDto.Password = item.Password;
                    userLoginDto.CreationDate = Convert.ToDateTime(item.CreationDate); //TODO: tarih parse işlemi gerekiyor mu?
                    userLoginDto.IpAdress = item.IpAdress;
                    userLoginDto.UserID = Convert.ToInt32(item.UserID);

                    return userLoginDto;
                }
            }
            catch (Exception)
            {
                return new UserLoginDto();
            }
        }
        public ResultHelper DelUserLogin(int userLoginID)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var selectedUserLoginID = unitOfWork.GetRepository<userlogin>().GetById(x => x.UserLoginID == userLoginID);
                    unitOfWork.GetRepository<userlogin>().Delete(selectedUserLoginID);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, selectedUserLoginID.UserLoginID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);

                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, userLoginID, ResultHelper.UnSuccessMessage);
            }
        }
        public bool IsThere(UserLoginDto userLoginDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<userlogin>().GetById(x => x.UserLoginID == userLoginDto.UserLoginID && x.Password == userLoginDto.Password && x.CreationDate == userLoginDto.CreationDate && x.IpAdress == userLoginDto.IpAdress && x.UserID == userLoginDto.UserID);
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
        public UserLoginDto SendMail(string Email)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<usercontact>().GetById(x => x.Contact == Email);
                var item1 = unitofWork.GetRepository<userpassword>().GetById(x =>x.UserID == item.UserID);
                UserLoginDto userLoginDto = new UserLoginDto();
                userLoginDto.Password = item1.Password;
                if (item != null)
                {
                    return userLoginDto;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
