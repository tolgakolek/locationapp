using LocationApp.Core.Core;
using LocationApp.Data.Dto;
using LocationApp.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LocationApp.Service.Services
{
    public class UserTitleService : IUserTitleService
    {
        private UserTitleLogic userTitleLogic = new UserTitleLogic();
        public string DelUserTitle(int userTitleId)
        {
            return JsonConvert.SerializeObject(userTitleLogic.DelUserTitle(userTitleId));
        }
        public string GetUserTitle(int userTitleId)
        {
            return JsonConvert.SerializeObject(userTitleLogic.GetUserTitle(userTitleId));
        }
        public string GetAllUserTitle()
        {
           return JsonConvert.SerializeObject(userTitleLogic.GetAllUserTitle(), Formatting.Indented);
        }
        public string AddUserTitle(UserTitleDto userTitleDto)
        {
            return JsonConvert.SerializeObject(userTitleLogic.AddUserTitle(userTitleDto));
        }
        public string SetUserTitle(UserTitleDto userTitleDto)
        {
            return JsonConvert.SerializeObject(userTitleLogic.SetUserTitle(userTitleDto));
        }
    }
}
