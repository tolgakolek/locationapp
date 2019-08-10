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
    public class CampusLogic
    {
        public ResultHelper AddCampus(CampusDto campusDto)
        {
            try
            {
                if (IsThere(campusDto))
                    return new ResultHelper(false, campusDto.CampusID, ResultHelper.IsThereItem);

                campu item = new campu();
                item.Name = campusDto.Name;
                item.CampusID = campusDto.CampusID;
                item.Description = campusDto.Description;
                item.Other = campusDto.Other;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<campu>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.CampusID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, campusDto.CampusID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetCampus(CampusDto campusDto)
        {
            try
            {
                campu item = new campu();
                item.CampusID = campusDto.CampusID;
                item.Description = campusDto.Description;
                item.Other = campusDto.Other;
                item.Name = campusDto.Name;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<campu>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, campusDto.CampusID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, campusDto.CampusID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelCampus(int campusID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedCampus = unitofWork.GetRepository<campu>().GetById(x => x.CampusID == campusID);
                    unitofWork.GetRepository<campu>().Delete(selectedCampus);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, campusID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, campusID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public CampusDto GetCampus(int campusID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    campu item = new campu();
                    item = unitofWork.GetRepository<campu>().GetById(x => x.CampusID == campusID);
                    CampusDto campusDto = new CampusDto();
                    campusDto.CampusID = item.CampusID;
                    campusDto.Name = item.Name;
                    campusDto.Description = item.Description;
                    campusDto.Other = item.Other;
                    return campusDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<CampusDto> GetAllCampus()
        {
            try
            {
                List<CampusDto> list = new List<CampusDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<campu> collection = unitofWork.GetRepository<campu>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new CampusDto { CampusID = item.CampusID, Description = item.Description, Name = item.Name, Other = item.Other });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<CampusDto>();
            }
        }
        public bool IsThere(CampusDto campusDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<campu>().GetById(x => x.Name.ToUpper() == campusDto.Name.ToUpper());
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
