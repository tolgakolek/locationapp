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
    public class BlockService : IBlockService
    {
        private Core.Core.BlockLogic blockLogic = new Core.Core.BlockLogic();
        public string AddBlock(BlockDto blockDto)
        {
            return JsonConvert.SerializeObject(blockLogic.AddBlock(blockDto));
        }
        public string DeleteBlock(int blockID)
        {
            return JsonConvert.SerializeObject(blockLogic.DelBlock(blockID));
        }
        public string GetBlock(int blockID)
        {
            return JsonConvert.SerializeObject(blockLogic.GetBlock(blockID));
        }
        public string SetBlock(BlockDto blockDto)
        {
            return JsonConvert.SerializeObject(blockLogic.SetBlock(blockDto));
        }
        public string GetAllBlock()
        {
            return JsonConvert.SerializeObject(blockLogic.GetAllBlock(), Formatting.Indented);
        }
        public string GetAllBlockWithByBuildID(int buildID)
        {
            return JsonConvert.SerializeObject(blockLogic.GetAllBlockWithByBuildID(buildID), Formatting.Indented);
        }
    }
}