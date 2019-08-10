using LocationApp.Core.Helper;
using LocationApp.Data.Database;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Core.Core
{
    public class BlockLogic
    {
        public ResultHelper AddBlock(BlockDto blockDto)
        {
            try
            {
                if (IsThere(blockDto))
                {
                    return new ResultHelper(false, 0, ResultHelper.IsThereItem);
                }
                block item = new block();
                item.BlockID = blockDto.BlockID;
                item.BuildID = blockDto.BuildID;
                item.Name = blockDto.Name;
                item.Gps = blockDto.Gps;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<block>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.BlockID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetBlock(BlockDto blockDto)
        {
            try
            {
                block item = new block();
                item.BlockID = blockDto.BlockID;
                item.BuildID = blockDto.BuildID;
                item.Name = blockDto.Name;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<block>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.BlockID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, blockDto.BlockID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelBlock(int blockID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedBlock = unitofWork.GetRepository<block>().GetById(x => x.BlockID == blockID);
                    unitofWork.GetRepository<block>().Delete(selectedBlock);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selectedBlock.BlockID,ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, blockID, ResultHelper.UnSuccessMessage);
            }
        }
        public BlockDto GetBlock(int blockID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    block item = new block();
                    item = unitofWork.GetRepository<block>().GetById(x => x.BlockID == blockID);
                    BlockDto blockDto = new BlockDto();
                    blockDto.BlockID = (int)item.BlockID;
                    blockDto.BuildID = (int)item.BuildID;
                    blockDto.Name = item.Name;
                    blockDto.Gps = item.Gps;
                    return blockDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<BlockDto> GetAllBlock()
        {
            try
            {
                List<BlockDto> list = new List<BlockDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<block> collection = unitofWork.GetRepository<block>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        BlockDto blockDto = new BlockDto();
                        blockDto.Name = item.Name;
                        blockDto.BlockID = item.BlockID;
                        blockDto.BuildID = item.BuildID.Value;
                        blockDto.Gps = item.Gps;

                        var build = unitofWork.GetRepository<build>().GetById(model => model.BuildID == item.BuildID);
                        BuildDto buildDto = new BuildDto();
                        buildDto.BuildID = build.BuildID;
                        buildDto.Name = build.Name;
                        buildDto.Address = build.Adress;
                        buildDto.Gps = build.Gps;
                        buildDto.CampusID = build.CampusID.Value;
                        buildDto.SiteID = build.SiteID.Value;
                        buildDto.Properties = build.Properties;
                        blockDto.BuildDto = buildDto;

                        list.Add(blockDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<BlockDto>();
            }
        }
        public List<BlockDto> GetAllBlockWithByBuildID(int buildID)
        {
            try
            {
                List<BlockDto> list = new List<BlockDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<block> collection = unitofWork.GetRepository<block>().Select(null, x => x.BuildID == buildID).ToList();
                    foreach (var item in collection)
                    {
                        BlockDto blockDto = new BlockDto();
                        blockDto.Name = item.Name;
                        blockDto.BlockID = item.BlockID;
                        blockDto.BuildID = item.BuildID.Value;
                        blockDto.Gps = item.Gps;
                        list.Add(blockDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<BlockDto>();
            }
        }
        public bool IsThere(BlockDto blockDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<block>().GetById(x => x.BuildID == blockDto.BuildID && x.Name == blockDto.Name);
                if (item != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}