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
    public class SubUnitService : ISubUnitService
    {
        private SubUnitLogic subUnitLogic = new SubUnitLogic();
        public string AddSubUnit(SubUnitDto subUnitDto)
        {
            return JsonConvert.SerializeObject(subUnitLogic.AddSubUnit(subUnitDto));
        }
        public string SetSubUnit(SubUnitDto subUnitDto)
        {
            return JsonConvert.SerializeObject(subUnitLogic.SetSubUnit(subUnitDto));
        }
        public string DelSubUnit(int subUnitID)
        {
            return JsonConvert.SerializeObject(subUnitLogic.DelSubUnit(subUnitID));
        }
        public string GetSubUnit(int subUnitID)
        {
            return JsonConvert.SerializeObject(subUnitLogic.GetSubUnit(subUnitID));
        }
        public string GetAllSubUnit()
        {
            return JsonConvert.SerializeObject(subUnitLogic.GetAllSubUnit(), Formatting.Indented);
        }
        public string GetAllSubUnitWithByMainUnitID(int mainUnitID)
        {
            return  JsonConvert.SerializeObject(subUnitLogic.GetAllWithByMainUnitID(mainUnitID), Formatting.Indented);
        }
    }
}
