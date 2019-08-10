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
    public class BuildService : IBuildService
    {
        private Core.Core.BuildLogic buildLogic = new Core.Core.BuildLogic();
        public string AddBuild(BuildDto buildDto)
        {
            return JsonConvert.SerializeObject(buildLogic.AddBuild(buildDto));
        }
        public string DelBuild(int buildID)
        {
            return JsonConvert.SerializeObject(buildLogic.DelBuild(buildID));
        }
        public string GetBuild(int buildID)
        {
            return JsonConvert.SerializeObject(buildLogic.GetBuild(buildID));
        }
        public string SetBuild(BuildDto buildDto)
        {
            return JsonConvert.SerializeObject(buildLogic.SetBuild(buildDto));
        }
        public string GetAllBuild()
        {
            return JsonConvert.SerializeObject(buildLogic.GetAllBuild(), Formatting.Indented);
        }
    }
}