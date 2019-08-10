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
    public class BuildLogic
    {
        public ResultHelper AddBuild(BuildDto buildDto)
        {
            try
            {
                if (IsThere(buildDto))
                    return new ResultHelper(false, 0, ResultHelper.IsThereItem);

                build item = new build();
                if (buildDto.SiteID == 0)
                    item.SiteID = null;
                else
                    item.SiteID = buildDto.SiteID;
                item.BuildID = buildDto.BuildID;
                item.CampusID = buildDto.CampusID;
                item.Gps = buildDto.Gps;
                item.Name = buildDto.Name;
                item.Adress = buildDto.Address;
                item.Properties = buildDto.Properties;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<build>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.BuildID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetBuild(BuildDto buildDto)
        {
            try
            {
                build item = new build();
                if (buildDto.SiteID == 0)
                    item.SiteID = null;
                else
                    item.SiteID = buildDto.SiteID;
                item.BuildID = buildDto.BuildID;
                item.CampusID = buildDto.CampusID;
                item.Gps = buildDto.Gps;
                item.Name = buildDto.Name;
                item.Adress = buildDto.Address;
                item.Properties = buildDto.Properties;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<build>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, buildDto.BuildID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, buildDto.BuildID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelBuild(int buildID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedBuild = unitofWork.GetRepository<build>().GetById(x => x.BuildID == buildID);
                    unitofWork.GetRepository<build>().Delete(selectedBuild);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, buildID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, buildID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public BuildDto GetBuild(int buildID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    build item = new build();
                    item = unitofWork.GetRepository<build>().GetById(x => x.BuildID == buildID);
                    BuildDto buildDto = new BuildDto();
                    buildDto.BuildID = item.BuildID;
                    buildDto.SiteID = (int)item.SiteID;
                    buildDto.CampusID = (int)item.CampusID;
                    buildDto.Name = item.Name;
                    buildDto.Address = item.Adress;
                    buildDto.Gps = item.Gps;
                    buildDto.Properties = item.Properties;
                    return buildDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<BuildDto> GetAllBuild()
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<BuildDto> list = new List<BuildDto>();
                    var buildList = from b in unitofWork.GetRepository<build>().Select(null, null)
                                    join c in unitofWork.GetRepository<campu>().Select(null, null) on b.CampusID equals c.CampusID
                                    join s in unitofWork.GetRepository<site>().Select(null, null) on b.SiteID equals s.SiteID into site
                                    from s in site.DefaultIfEmpty()
                                    select new
                                    {
                                        BID = b.BuildID,
                                        BName = b.Name,
                                        BAdress = b.Adress,
                                        BGps = b.Gps,
                                        BProperties = b.Properties,
                                        BCID = b.CampusID,
                                        CID = c.CampusID,
                                        CName = c.Name,
                                        CDesc = c.Description,
                                        COther = c.Other,
                                        SID = s == null ? 0 : s.SiteID,
                                        SName = s == null ? "(-)" : s.Name,
                                        SDesc = s == null ? "(-)" : s.Description,
                                        SGps = s == null ? "(-)" : s.Gps,
                                    };
                    foreach (var item in buildList)
                    {
                        BuildDto bDto = new BuildDto();
                        bDto.BuildID = item.BID;
                        bDto.Name = item.BName;
                        bDto.Address = item.BAdress;
                        bDto.CampusID = item.BCID.Value;
                        bDto.Properties = item.BProperties;
                        bDto.CampusDto = new CampusDto();
                        bDto.CampusDto.CampusID = item.CID;
                        bDto.CampusDto.Name = item.CName;
                        bDto.CampusDto.Description = item.CDesc;
                        bDto.CampusDto.Other = item.COther;
                        bDto.SiteDto = new SiteDto();
                        bDto.SiteDto.SiteID = item.SID;
                        bDto.SiteDto.Name = item.SName;
                        bDto.SiteDto.Description = item.SDesc;
                        bDto.SiteDto.Gps = item.SGps;
                        list.Add(bDto);

                    }

                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<BuildDto>();
            }
        }
        public bool IsThere(BuildDto buildDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<build>().GetById(x => x.Name == buildDto.Name);
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
