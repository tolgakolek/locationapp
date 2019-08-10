using LocationApp.Service.Interfaces;
using LocationApp.Core.Core;
using LocationApp.Data.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LocationApp.Service.Services
{
    public class FloorService : IFloorService
    {
        private FloorLogic floorLogic = new FloorLogic();
        public string AddFloor(FloorDto floorDto)
        {
            return JsonConvert.SerializeObject(floorLogic.AddFloor(floorDto));
        }
        public string DelFloor(int floorID)
        {
            return JsonConvert.SerializeObject(floorLogic.DelFloor(floorID));
        }
        public string GetFloor(int floorID)
        {
            return JsonConvert.SerializeObject(floorLogic.GetFloor(floorID));
        }
        public string SetFloor(FloorDto floorDto)
        {
            return JsonConvert.SerializeObject(floorLogic.SetFloor(floorDto));
        }
        public string GetAllFloor()
        {
            return JsonConvert.SerializeObject(floorLogic.GetAllFloor(), Formatting.Indented);
        }
        public string GetAllFloorByBlockID(int blockID)
        {
            return JsonConvert.SerializeObject(floorLogic.GetAllFloorByBlockID(blockID), Formatting.Indented);
        }
        public string GetAllFloorByBuildID(int buildID)
        {
            return JsonConvert.SerializeObject(floorLogic.GetAllFloorByBuildID(buildID), Formatting.Indented);
        }
    }
}
