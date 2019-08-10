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
    public class UserContactTypeLogic
    {
        public ResultHelper AddUserContactType(UserContactTypeDto userContactTypeDto)
        {
            try
            {
                if (IsThere(userContactTypeDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.SuccessMessage);
                }
                usercontacttype item = new usercontacttype();
                item.UserContactTypeID = userContactTypeDto.UserContactTypeID;
                item.TypeName = userContactTypeDto.TypeName;
                item.Description = userContactTypeDto.Description;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<usercontacttype>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserContactTypeID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserContactType(UserContactTypeDto userContactTypeDto)
        {
            try
            {
                usercontacttype item = new usercontacttype();
                item.UserContactTypeID = userContactTypeDto.UserContactTypeID;
                item.TypeName = userContactTypeDto.TypeName;
                item.Description = userContactTypeDto.Description;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<usercontacttype>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserContactTypeID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, userContactTypeDto.UserContactTypeID, ResultHelper.UnSuccessMessage);
            }
        }
        public UserContactTypeDto GetUserContactType(int userContactTypeID)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    usercontacttype item = new usercontacttype();
                    item = unitOfWork.GetRepository<usercontacttype>().GetById(x => x.UserContactTypeID == userContactTypeID);
                    UserContactTypeDto userContactTypeDto = new UserContactTypeDto();
                    userContactTypeDto.TypeName = item.TypeName;
                    userContactTypeDto.UserContactTypeID = item.UserContactTypeID;
                    userContactTypeDto.Description = item.Description;

                    return userContactTypeDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ResultHelper DelUserContactType(int userContactTypeID)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var selectedUserContactType = unitOfWork.GetRepository<usercontacttype>().GetById(x => x.UserContactTypeID == userContactTypeID);
                    unitOfWork.GetRepository<usercontacttype>().Delete(selectedUserContactType);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, selectedUserContactType.UserContactTypeID, ResultHelper.SuccessMessage);

                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, userContactTypeID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public List<UserContactTypeDto> GetAllUserContactType()
        {
            try
            {
                List<UserContactTypeDto> list = new List<UserContactTypeDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<usercontacttype> collection = unitofWork.GetRepository<usercontacttype>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new UserContactTypeDto { UserContactTypeID = item.UserContactTypeID, TypeName = item.TypeName, Description = item.Description });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserContactTypeDto>();
            }
        }
        public bool IsThere(UserContactTypeDto userContactTypeDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<usercontacttype>().GetById(x => x.UserContactTypeID == userContactTypeDto.UserContactTypeID && x.TypeName == userContactTypeDto.TypeName && x.Description == userContactTypeDto.Description);
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
