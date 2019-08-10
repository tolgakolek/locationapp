using System;
using LocationApp.Core.Core;
using LocationApp.Data.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LocationApp.Service.Interfaces;

namespace LocationApp.Service.Services
{
    public class MainUnitService : IMainUnitService
    {
        private MainUnitLogic mainUnitLogic = new MainUnitLogic();
       
        public string AddMainUnit(MainUnitDto mainUnitDto)
        {
            return JsonConvert.SerializeObject(mainUnitLogic.AddMainUnit(mainUnitDto));
        }
        public string SetMainUnit(MainUnitDto mainUnitDto)
        {
            return JsonConvert.SerializeObject(mainUnitLogic.SetMainUnit(mainUnitDto));
        }
        public string DelMainUnit(int mainUnitID)
        {
            return JsonConvert.SerializeObject(mainUnitLogic.DelMainUnit(mainUnitID));
        }

        public string GetMainUnit(int mainUnitID)
        {
            return JsonConvert.SerializeObject(mainUnitLogic.GetMainUnit(mainUnitID));
        }
        public string GetAllMainUnit()
        {
            return JsonConvert.SerializeObject(mainUnitLogic.GetAllMainUnit(), Formatting.Indented);
        }
    }
}
