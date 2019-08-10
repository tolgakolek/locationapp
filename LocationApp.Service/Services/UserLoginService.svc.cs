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
    public class UserLoginService : IUserLoginService
    {
        private UserLoginLogic userLoginLogic = new UserLoginLogic();
        public string AddUserLogin(UserLoginDto userLoginDto)
        {
            return JsonConvert.SerializeObject(userLoginLogic.AddUserLogin(userLoginDto));
        }
        public string DelUserLogin(int userLoginID)
        {
            return JsonConvert.SerializeObject(userLoginLogic.DelUserLogin(userLoginID));
        }
        public string GetUserLogin(int userLoginID)
        {
            return JsonConvert.SerializeObject(userLoginLogic.GetUserLogin(userLoginID));
        }

        public string SendMail(string Email)
        {
            return JsonConvert.SerializeObject(userLoginLogic.SendMail(Email));
        }

        public string SetUserLogin(UserLoginDto userLoginDto)
        {
            return JsonConvert.SerializeObject(userLoginLogic.SetUserLogin(userLoginDto));
        }
    }
}
