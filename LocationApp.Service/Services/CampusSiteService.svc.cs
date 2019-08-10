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
    public class CampusSiteService : ICampusSiteService
    {
        private Core.Core.CampusSiteLogic campusSiteLogic = new Core.Core.CampusSiteLogic();
        public string AddCampusSite(CampusSiteDto campusSiteDto)
        {
            return JsonConvert.SerializeObject(campusSiteLogic.AddCampusSite(campusSiteDto));
        }
        public string DelCampusSite(int campusSiteID)
        {
            return JsonConvert.SerializeObject(campusSiteLogic.DelCampusSite(campusSiteID));
        }
        public string GetCampusSite(int campusSiteID)
        {
            return JsonConvert.SerializeObject(campusSiteLogic.GetCampusSite(campusSiteID));
        }
        public string SetCampusSite(CampusSiteDto campusSiteDto)
        {
            return JsonConvert.SerializeObject(campusSiteLogic.SetCampusSite(campusSiteDto));
        }
    }
}
