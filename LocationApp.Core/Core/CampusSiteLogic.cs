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
    public class CampusSiteLogic
    {
        public ResultHelper AddCampusSite(CampusSiteDto campusSiteDto)
        {
            try
            {
                campussite item = new campussite();
                item.CampusID = campusSiteDto.CampusID;
                item.CampusSiteID = campusSiteDto.CampusSiteID;
                item.SiteID = campusSiteDto.SiteID;
                item.Other = campusSiteDto.Other;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<campussite>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.CampusSiteID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, campusSiteDto.CampusSiteID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetCampusSite(CampusSiteDto campusSiteDto)
        {
            try
            {
                campussite item = new campussite();
                item.CampusID = campusSiteDto.CampusID;
                item.CampusSiteID = campusSiteDto.CampusSiteID;
                item.SiteID = campusSiteDto.SiteID;
                item.Other = campusSiteDto.Other;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<campussite>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, campusSiteDto.CampusSiteID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, campusSiteDto.CampusSiteID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelCampusSite(int campusSiteID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedCampus = unitofWork.GetRepository<campussite>().GetById(x => x.CampusSiteID == campusSiteID);
                    unitofWork.GetRepository<campussite>().Delete(selectedCampus);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, campusSiteID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(true, campusSiteID, ResultHelper.UnSuccessMessage);
            }
        }
        public CampusSiteDto GetCampusSite(int campusSiteID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    campussite item = new campussite();
                    item = unitofWork.GetRepository<campussite>().GetById(x => x.CampusSiteID == campusSiteID);
                    CampusSiteDto campusSiteDto = new CampusSiteDto();
                    campusSiteDto.CampusID = (int)item.CampusID;
                    campusSiteDto.CampusSiteID = item.CampusSiteID;
                    campusSiteDto.SiteID = (int)item.SiteID;
                    campusSiteDto.Other = item.Other;

                    return campusSiteDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
