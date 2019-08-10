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
     public class UserDepartmentService : IUserDepartmentService
    {
        private UserDepartmenLogic userDepartmentLogic = new UserDepartmenLogic();
        public string AddUserDepartment(UserDepartmentDto userDepartmentDto)
        {
            return JsonConvert.SerializeObject(userDepartmentLogic.AddUserDepartment(userDepartmentDto));
        }
        public string DelUserDepartment(int UserDepartmentID)
        {
            return JsonConvert.SerializeObject(userDepartmentLogic.DelUserDepartment(UserDepartmentID));
        }
        public string GetAllUserDepartment()
        {
           return JsonConvert.SerializeObject(userDepartmentLogic.GetAllUserDepartment(), Formatting.Indented);
        }
        public string GetUserDepartment(int UserDepartmentID)
        {
            return JsonConvert.SerializeObject(userDepartmentLogic.GetUserDepartment(UserDepartmentID));
        }
        public string SetUserDepartment(UserDepartmentDto userDepartmentDto)
        {
            return JsonConvert.SerializeObject(userDepartmentLogic.SetUserDepartment(userDepartmentDto));
        }
    }
}
