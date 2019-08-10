using LocationApp.Data.Dto;
using LocationApp.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LocationApp.Core.Core;

namespace LocationApp.Service.Services
{
    public class DeviceTypeService : IDeviceTypeService
    {
        Core.Core.DeviceTypeLogic deviceTypeLogic = new DeviceTypeLogic();
        public string AddDeviceType(DeviceTypeDto deviceTypeDto)
        {
            return JsonConvert.SerializeObject(deviceTypeLogic.AddDeviceType(deviceTypeDto));
        }
        public string DelDeviceType(int deviceTypeID)
        {
            return JsonConvert.SerializeObject(deviceTypeLogic.DelDeviceType(deviceTypeID));
        }
        public string GetAllDeviceType()
        {
            return JsonConvert.SerializeObject(deviceTypeLogic.GetAllDeviceType());
        }
        public string GetDeviceType(int deviceTypeID)
        {
            return JsonConvert.SerializeObject(deviceTypeLogic.GetDeviceType(deviceTypeID));
        }
        public string SetDeviceType(DeviceTypeDto deviceTypeDto)
        {
            return JsonConvert.SerializeObject(deviceTypeLogic.SetDeviceType(deviceTypeDto));
        }
    }
}
