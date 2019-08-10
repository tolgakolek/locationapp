using LocationApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LocationApp.Core.Core;
using Newtonsoft.Json;
using LocationApp.Data.Dto;

namespace LocationApp.Service.Services
{
    public class DepartmentRoomService : IDepartmentRoomService
    {
        private DepartmentRoomLogic departmentRoomLogic = new DepartmentRoomLogic();
        public string AddDepartmentRoom(DepartmentRoomDto departmentRoomDto)
        {
            return JsonConvert.SerializeObject(departmentRoomLogic.AddDepartmentRoom(departmentRoomDto));
        }
        public string SetDepartmentRoom(DepartmentRoomDto departmentRoomDto)
        {
            return JsonConvert.SerializeObject(departmentRoomLogic.SetDepartmentRoom(departmentRoomDto));
        }
        public string GetDepartmentRoom(int departmentRoomID)
        {
            return JsonConvert.SerializeObject(departmentRoomLogic.GetDepartmentRoom(departmentRoomID));
        }
        public string DelDepartmentRoom(int departmentRoomID)
        {
            return JsonConvert.SerializeObject(departmentRoomLogic.DelDepartmentRoom(departmentRoomID));
        }
    }
}
