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
     public class SiteService : ISiteService
    {
        private SiteLogic siteLogic = new SiteLogic();
        public string AddSite(SiteDto siteDto)
        {
            return JsonConvert.SerializeObject(siteLogic.AddSite(siteDto));
        }
        public string SetSite(SiteDto siteDto)
        {
            return JsonConvert.SerializeObject(siteLogic.SetSite(siteDto));
        }
        public string DelSite(int roomID)
        {
            return JsonConvert.SerializeObject(siteLogic.DelSite(roomID));
        }
        public string GetSite(int siteID)
        {
            return JsonConvert.SerializeObject(siteLogic.GetSite(siteID));
        }

        public string GetAllSite()
        {
            return JsonConvert.SerializeObject(siteLogic.GetAllSite(), Formatting.Indented);
        }
        public string GetAllSiteWithCampus(int campusID)
        {
            return JsonConvert.SerializeObject(siteLogic.GetSiteWithCampus(campusID), Formatting.Indented);
        }
    }
}
