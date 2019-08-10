using LocationApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LocationApp.Data;
using LocationApp.Core.Core;
using Newtonsoft.Json;
using LocationApp.Data.Dto;
using LocationApp.Data.Database;
using LocationApp.Data.UnitOfWork;

namespace LocationApp.Service.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private RoomTypeLogic roomTypeLogic = new RoomTypeLogic();
        public string AddRoomType(RoomTypeDto roomTypeDto)
        {
            return JsonConvert.SerializeObject(roomTypeLogic.AddRoomType(roomTypeDto));
        }
        public string SetRoomType(RoomTypeDto roomTypeDto)
        {
            return JsonConvert.SerializeObject(roomTypeLogic.AddRoomType(roomTypeDto));
        }
        public string DelRoomType(int RoomTypeID)
        {
            return JsonConvert.SerializeObject(roomTypeLogic.DelRoomType(RoomTypeID));
        }
        public string GetRoomType(int RoomTypeID)
        {
            return JsonConvert.SerializeObject(roomTypeLogic.GetRoomType(RoomTypeID));
        }
        public string GetAllRoomType()
        {
            return JsonConvert.SerializeObject(roomTypeLogic.GetAllRoomType(), Formatting.Indented);
        }

    }
}
