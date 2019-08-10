using LocationApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LocationApp.Core.Core;
using LocationApp.Data.Dto;
using Newtonsoft.Json;

namespace LocationApp.Service.Services
{
    public class DeviceRoomService : IDeviceRoomService
    {
        Core.Core.DeviceRoomLogic deviceRoomLogic = new DeviceRoomLogic();
        public string AddDeviceRoom(DeviceRoomDto deviceRoomDto)
        {
            return JsonConvert.SerializeObject(deviceRoomLogic.AddDeviceRoom(deviceRoomDto));
        }
        public string DelDeviceRoom(int deviceRoomID)
        {
            return JsonConvert.SerializeObject(deviceRoomLogic.DelDeviceRoom(deviceRoomID));
        }
        public string GetAllDeviceRoom()
        {
           return JsonConvert.SerializeObject(deviceRoomLogic.GetAllDeviceRoom(), Formatting.Indented);
        }
        public string GetDeviceRoom(int deviceRoomID)
        {
            return JsonConvert.SerializeObject(deviceRoomLogic.GetDeviceRoom(deviceRoomID));
        }
        public string SetDeviceRoom(DeviceRoomDto deviceRoomDto)
        {
            return JsonConvert.SerializeObject(deviceRoomLogic.SetDeviceRoom(deviceRoomDto));
        }
    }
}
