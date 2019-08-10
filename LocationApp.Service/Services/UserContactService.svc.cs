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
    public class UserContactService : IUserContactService
    {
        private UserContactLogic userContactLogic = new UserContactLogic();
        public string AddUserContact(UserContactDto userContactDto)
        {
            return JsonConvert.SerializeObject(userContactLogic.AddUserContact(userContactDto));
        }
        public string DelUserContact(int UserContactID)
        {
            return JsonConvert.SerializeObject(userContactLogic.DelUserContact(UserContactID));
        }
        public string GetAllUserContact()
        {
            return JsonConvert.SerializeObject(userContactLogic.GetAllUserContact(), Formatting.Indented);
        }
        public string GetUserContact(int UserContactID)
        {
            return JsonConvert.SerializeObject(userContactLogic.GetUserContact(UserContactID));
        }
        public string SetUserContact(UserContactDto userContactDto)
        {
            return JsonConvert.SerializeObject(userContactLogic.SetUserContact(userContactDto));
        }
    }
}
