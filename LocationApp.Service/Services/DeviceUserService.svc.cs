using LocationApp.Data.Dto;
using LocationApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LocationApp.Core.Core;
using Newtonsoft.Json;

namespace LocationApp.Service.Services
{
    public class DeviceUserService : IDeviceUserService
    {
        Core.Core.DeviceUserLogic deviceUserLogic = new DeviceUserLogic();
        public string AddDeviceUser(DeviceUserDto deviceUserDto)
        {
            return JsonConvert.SerializeObject(deviceUserLogic.AddDeviceUser(deviceUserDto));
        }
        public string DelDeviceUser(int deviceUserID)
        {
            return JsonConvert.SerializeObject(deviceUserLogic.DelDeviceUser(deviceUserID));
        }
        public string GetAllDeviceUser()
        {
            return JsonConvert.SerializeObject(deviceUserLogic.GetAllDeviceUser());
        }
        public string GetDeviceUser(int deviceUserID)
        {
            return JsonConvert.SerializeObject(deviceUserLogic.GetDeviceUser(deviceUserID));
        }
        public string SetDeviceUser(DeviceUserDto deviceUserDto)
        {
            return JsonConvert.SerializeObject(deviceUserLogic.SetDeviceUser(deviceUserDto));
        }
    }
}
