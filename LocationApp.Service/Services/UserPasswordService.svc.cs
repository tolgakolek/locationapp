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
   public class UserPasswordService : IUserPasswordService
    {
        private UserPasswordLogic userPasswordLogic = new UserPasswordLogic();
        public string AddUserPassword(UserPasswordDto userPasswordDto)
        {
            return JsonConvert.SerializeObject(userPasswordLogic.AddUserPassword(userPasswordDto));
        }
        public string DelUserPassword(int userPasswordID)
        {
            return JsonConvert.SerializeObject(userPasswordLogic.DelUserPassword(userPasswordID));
        }
        public string GetUserPassword(int userPasswordID)
        {
            return JsonConvert.SerializeObject(userPasswordLogic.GetUserPassword(userPasswordID));
        }
        public string SetUserPassword(UserPasswordDto userPasswordDto)
        {
            return JsonConvert.SerializeObject(userPasswordLogic.SetUserPassword(userPasswordDto));
        }
    }
}
