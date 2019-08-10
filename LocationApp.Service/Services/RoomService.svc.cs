using LocationApp.Core.Core;
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
     public class RoomService : IRoomService
    {
        private RoomLogic roomLogic = new RoomLogic();
        public string AddRoom(RoomDto roomDto)
        {
            return JsonConvert.SerializeObject(roomLogic.AddRoom(roomDto));
        }
        public string SetRoom(RoomDto roomDto)
        {
            return JsonConvert.SerializeObject(roomLogic.SetRoom(roomDto));
        }
        public string DelRoom(int roomID)
        {
            return JsonConvert.SerializeObject(roomLogic.DelRoom(roomID));
        }
        public string GetRoom(int roomID)
        {
            return JsonConvert.SerializeObject(roomLogic.GetRoom(roomID));
        }
        public string GetAllRoom()
        {
            return JsonConvert.SerializeObject(roomLogic.GetAllRooms(), Formatting.Indented);
        }
    }
}
