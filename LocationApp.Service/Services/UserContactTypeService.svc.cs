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
    public class UserContactTypeService : IUserContactTypeService
    {
        private UserContactTypeLogic userContactTypeLogic = new UserContactTypeLogic();
        public string AddUserContactType(UserContactTypeDto userContactTypeDto)
        {
            return JsonConvert.SerializeObject(userContactTypeLogic.AddUserContactType(userContactTypeDto));
        }
        public string DelUserContactType(int userContactTypeID)
        {
            return JsonConvert.SerializeObject(userContactTypeLogic.DelUserContactType(userContactTypeID));
        }
        public string GetAllUserContactType()
        {
            return JsonConvert.SerializeObject(userContactTypeLogic.GetAllUserContactType(), Formatting.Indented);
        }
        public string GetUserContactType(int userContactTypeID)
        {
            return JsonConvert.SerializeObject(userContactTypeLogic.GetUserContactType(userContactTypeID));
        }
        public string SetUserContactType(UserContactTypeDto userContactTypeDto)
        {
            return JsonConvert.SerializeObject(userContactTypeLogic.SetUserContactType(userContactTypeDto));
        }
    }
}
