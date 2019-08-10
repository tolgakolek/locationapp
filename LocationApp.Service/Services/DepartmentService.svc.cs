using LocationApp.Data.Dto;
using LocationApp.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LocationApp.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        Core.Core.DepartmentLogic departmentLogic = new Core.Core.DepartmentLogic();
        public string AddDepartment(DepartmentDto departmentDto)
        {
            return JsonConvert.SerializeObject(departmentLogic.AddDepartment(departmentDto));
        }
        public string DelDepartment(int departmentID)
        {
            return JsonConvert.SerializeObject(departmentLogic.DelDepartment(departmentID));
        }
        public string GetDepartment(int departmentID)
        {
            return JsonConvert.SerializeObject(departmentLogic.GetDepartment(departmentID));
        }
        public string SetDepartment(DepartmentDto departmentDto)
        {
            return JsonConvert.SerializeObject(departmentLogic.SetDepartment(departmentDto));
        }
        public string GetAllDepartment()
        {
            return JsonConvert.SerializeObject(departmentLogic.GetAllDepartment(), Formatting.Indented);
        }
    }
}
