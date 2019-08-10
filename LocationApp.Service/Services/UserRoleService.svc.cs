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
    public class UserRoleService : IUserRoleService
    {
        private UserRoleLogic userRoleLogic = new UserRoleLogic();
        public string AddUserRole(UserRoleDto userRoleDto)
        {
            return JsonConvert.SerializeObject(userRoleLogic.AddUserRole(userRoleDto));
        }
        public string DelUserRole(int userRoleID)
        {
            return JsonConvert.SerializeObject(userRoleLogic.DelUserRole(userRoleID));
        }
        public string GetAllUserRole()
        {
            return JsonConvert.SerializeObject(userRoleLogic.GetAllUserRole(), Formatting.Indented);
        }
        public string GetUserRole(int userRoleID)
        {
            return JsonConvert.SerializeObject(userRoleLogic.GetUserRole(userRoleID));
        }
        public string SetUserRole(UserRoleDto userRoleDto)
        {
            return JsonConvert.SerializeObject(userRoleLogic.SetUserRole(userRoleDto));
        }
    }
}
