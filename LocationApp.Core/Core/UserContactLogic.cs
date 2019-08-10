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
    public class UserContactLogic
    {
        public ResultHelper AddUserContact(UserContactDto userContactDto)
        {
            try
            {
                if (IsThere(userContactDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
                }
                usercontact item = new usercontact();
                item.UserID = userContactDto.UserID;
                item.UserContactID = userContactDto.UserContactID;
                item.UserContactTypeID = userContactDto.UserContactTypeID;
                item.Contact = userContactDto.Contact;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<usercontact>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserContactID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.IsThereItem);
            }
        }
        public ResultHelper SetUserContact(UserContactDto userContactDto)
        {
            try
            {
                usercontact item = new usercontact();
                item.UserContactID = userContactDto.UserContactID;
                item.UserID = userContactDto.UserID;
                item.UserContactTypeID = userContactDto.UserContactTypeID;
                item.Contact = userContactDto.Contact;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<usercontact>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserContactID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userContactDto.UserContactID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUserContact(int UserContactID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedUserContact = unitofWork.GetRepository<usercontact>().GetById(x => x.UserContactID == UserContactID);
                    unitofWork.GetRepository<usercontact>().Delete(selectedUserContact);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selectedUserContact.UserContactID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, UserContactID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserContactDto GetUserContact(int UserContactID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    usercontact item = new usercontact();
                    item = unitofWork.GetRepository<usercontact>().GetById(x => x.UserContactID == UserContactID);
                    UserContactDto userContactDto = new UserContactDto();
                    userContactDto.UserContactID = item.UserContactID;
                    userContactDto.UserID = item.UserID.Value;
                    userContactDto.UserContactTypeID = item.UserContactTypeID.Value;
                    userContactDto.Contact = item.Contact;

                    return userContactDto;
                }
            }
            catch (Exception)
            {
                return new UserContactDto();
            }
        }
        public List<UserContactDto> GetAllUserContact()
        {
            try
            {
                List<UserContactDto> list = new List<UserContactDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var query = from uc in unitofWork.GetRepository<usercontact>().Select(null, null)
                                join us in unitofWork.GetRepository<user>().Select(null, null) on uc.UserID equals us.UserID
                                join ut in unitofWork.GetRepository<usercontacttype>().Select(null, null) on uc.UserContactTypeID equals ut.UserContactTypeID
                                select new
                                {
                                    UserID = us.UserID,
                                    UserContactTypeID = ut.UserContactTypeID,
                                    UserContactTypeName = ut.TypeName,
                                    UserName = us.Name,
                                    UserSurName = us.SurName,
                                    ContactName = uc.Contact,
                                    ContactID = uc.UserContactID,
                                };

                    foreach (var item in query)
                    {
                        UserContactDto uc = new UserContactDto();
                        uc.UserContactID = item.ContactID;
                        uc.Contact = item.ContactName;
                        uc.UserDto = new UserDto();
                        uc.UserDto.UserID = item.UserID;
                        uc.UserDto.Name = item.UserName;
                        uc.UserDto.SurName = item.UserSurName;
                        uc.UserContactTypeDto = new UserContactTypeDto();
                        uc.UserContactTypeDto.UserContactTypeID = item.UserContactTypeID;
                        uc.UserContactTypeDto.TypeName = item.UserContactTypeName;
                        list.Add(uc);
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserContactDto>();
            }
        }
        public bool IsThere(UserContactDto userContactDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<usercontact>().GetById(x => x.Contact == userContactDto.Contact && x.UserID == userContactDto.UserID && x.UserContactTypeID == userContactDto.UserContactTypeID);
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