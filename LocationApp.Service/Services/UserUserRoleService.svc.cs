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
     public class UserUserRoleService : IUserUserRoleService
    {
        private UserUserRoleLogic userUserRoleLogic = new UserUserRoleLogic();
        public string DelUserUserRole(int userUserRoleID)
        {
            return JsonConvert.SerializeObject(userUserRoleLogic.DelUserUserRole(userUserRoleID));
        }
        public string GetUserUserRole(int userUserRoleID)
        {
            return JsonConvert.SerializeObject(userUserRoleLogic.GetUserUserRole(userUserRoleID));
        }
        public string GetAllUserUserRole()
        {
            return JsonConvert.SerializeObject(userUserRoleLogic.GetAllUserUserRole(), Formatting.Indented);
        }
        public string AddUserUserRole(UserUserRoleDto userUserRoleDto)
        {
            return JsonConvert.SerializeObject(userUserRoleLogic.AddUserUserRole(userUserRoleDto));
        }
        public string SetUserUserRole(UserUserRoleDto userUserRoleDto)
        {
            return JsonConvert.SerializeObject(userUserRoleLogic.SetUserUserRole(userUserRoleDto));
        }
    }
}
