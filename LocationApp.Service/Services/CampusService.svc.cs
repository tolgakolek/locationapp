using LocationApp.Data.Database;
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
    public class CampusService : ICampusService
    {
        private Core.Core.CampusLogic campusLogic = new Core.Core.CampusLogic();
        public string AddCampus(CampusDto campusDto)
        {
            return JsonConvert.SerializeObject(campusLogic.AddCampus(campusDto));
        }
        public string SetCampus(CampusDto campusDto)
        {
            return JsonConvert.SerializeObject(campusLogic.SetCampus(campusDto));
        }
        public string DelCampus(int campusID)
        {
            return JsonConvert.SerializeObject(campusLogic.DelCampus(campusID));
        }
        public string GetCampus(int campusID)
        {
            return JsonConvert.SerializeObject(campusLogic.GetCampus(campusID), Formatting.Indented);
        }
        public string GetAllCampus()
        {
            return JsonConvert.SerializeObject(campusLogic.GetAllCampus(), Formatting.Indented);
        }
    }
}
