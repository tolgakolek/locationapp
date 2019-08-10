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
    public class DeviceService : IDeviceService
    {
        Core.Core.DeviceLogic deviceLogic = new DeviceLogic();
        public string AddDevice(DeviceDto deviceDto)
        {
            return JsonConvert.SerializeObject(deviceLogic.AddDevice(deviceDto));
        }
        public string DelDevice(int deviceID)
        {
            return JsonConvert.SerializeObject(deviceLogic.DelDevice(deviceID));
        }
        public string GetAllDevice()
        {
            return JsonConvert.SerializeObject(deviceLogic.GetAllDevices());
        }
        public string GetDevice(int deviceID)
        {
            return JsonConvert.SerializeObject(deviceLogic.GetDevice(deviceID));
        }
        public string SetDevice(DeviceDto deviceDto)
        {
            return JsonConvert.SerializeObject(deviceLogic.SetDevice(deviceDto));
        }
    }
}
