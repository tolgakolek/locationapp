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
    public class UserService : IUserService
    {
        private UserLogic userLogic = new UserLogic();
        public string AddUser(UserDto userDto)
        {
            return JsonConvert.SerializeObject(userLogic.AddUser(userDto));
        }
        public string DelUser(int userId)
        {
            return JsonConvert.SerializeObject(userLogic.DelUser(userId));
        }
        public string GetUser(int userId)
        {
            return JsonConvert.SerializeObject(userLogic.GetUser(userId));
        }
        public string GetAllUser()
        {
            return JsonConvert.SerializeObject(userLogic.GetAllUser(), Formatting.Indented);
        }
        public string SetUser(UserDto userDto)
        {
            return JsonConvert.SerializeObject(userLogic.SetUser(userDto),Formatting.Indented);
        }

        public string isLogin(string email, string password)
        {
            return JsonConvert.SerializeObject(userLogic.IsLogin(email, password), Formatting.Indented);
        }

        public string GetAllUserDepartments()
        {
            var item = JsonConvert.SerializeObject(userLogic.GetAllUserDepartments(), Formatting.Indented);
            return item;
        }
    }
}
