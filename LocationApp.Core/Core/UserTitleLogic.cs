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
    public class UserTitleLogic
    {
        public ResultHelper AddUserTitle(UserTitleDto userTitleDto)
        {
            try
            {
                if (IsThere(userTitleDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.IsThereItem);
                }
                usertitle item = new usertitle();
                item.UserTitleID = userTitleDto.UserTitleId;
                item.TitleName = userTitleDto.TitleName;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<usertitle>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserTitleID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUserTitle(UserTitleDto userTitleDto)
        {
            try
            {
                usertitle item = new usertitle();
                item.UserTitleID = userTitleDto.UserTitleId;
                item.TitleName = userTitleDto.TitleName;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<usertitle>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.UserTitleID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userTitleDto.UserTitleId, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUserTitle(int userTitleId)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedUserTitle = unitofWork.GetRepository<usertitle>().GetById(x => x.UserTitleID == userTitleId);
                    unitofWork.GetRepository<usertitle>().Delete(selectedUserTitle);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selectedUserTitle.UserTitleID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, userTitleId, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public UserTitleDto GetUserTitle(int userTitleId)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    usertitle item = new usertitle();
                    item = unitofWork.GetRepository<usertitle>().GetById(x => x.UserTitleID == userTitleId);
                    UserTitleDto userTitleDto = new UserTitleDto();
                    userTitleDto.TitleName = item.TitleName;
                    userTitleDto.UserTitleId = item.UserTitleID;

                    return userTitleDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<UserTitleDto> GetAllUserTitle()
        {
            try
            {
                List<UserTitleDto> list = new List<UserTitleDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<usertitle> collection = unitofWork.GetRepository<usertitle>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new UserTitleDto { TitleName = item.TitleName, UserTitleId = item.UserTitleID });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserTitleDto>();
            }
        }
        public bool IsThere(UserTitleDto userTitleDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<usertitle>().GetById(x => x.TitleName.ToLower() == userTitleDto.TitleName.ToLower());
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
