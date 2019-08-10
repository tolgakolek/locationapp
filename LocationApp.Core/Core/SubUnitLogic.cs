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
    public class SubUnitLogic
    {
        public ResultHelper AddSubUnit(SubUnitDto subUnitDto)
        {
            try
            {
                if (IsThere(subUnitDto))
                    return new ResultHelper(false, subUnitDto.SubUnitID, ResultHelper.IsThereItem);

                subunit item = new subunit();
                item.SubUnitID = subUnitDto.SubUnitID;
                item.MainUnitID = subUnitDto.MainUnitID;
                item.Name = subUnitDto.Name;
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<subunit>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.SubUnitID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, subUnitDto.SubUnitID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetSubUnit(SubUnitDto subUnitDto)
        {
            try
            {
                subunit item = new subunit();
                item.SubUnitID = subUnitDto.SubUnitID;
                item.MainUnitID = subUnitDto.MainUnitID;
                item.Name = subUnitDto.Name;
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<subunit>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.SubUnitID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, subUnitDto.SubUnitID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelSubUnit(int subUnitID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedSubUnit = unitofWork.GetRepository<subunit>().GetById(x => x.SubUnitID == subUnitID);
                    unitofWork.GetRepository<subunit>().Delete(selectedSubUnit);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, subUnitID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, subUnitID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public SubUnitDto GetSubUnit(int subUnitID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    subunit item = new subunit();
                    item = unitofWork.GetRepository<subunit>().GetById(x => x.SubUnitID == subUnitID);
                    SubUnitDto subUnitDto = new SubUnitDto();
                    subUnitDto.SubUnitID = item.SubUnitID;
                    subUnitDto.Name = item.Name;
                    subUnitDto.MainUnitID = (int)item.MainUnitID;
                    return subUnitDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SubUnitDto> GetAllSubUnit()
        {
            try
            {
                List<SubUnitDto> sDtoList = new List<SubUnitDto>();
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var subUnits = from s in unitOfWork.GetRepository<subunit>().Select(null, null)
                                   join m in unitOfWork.GetRepository<mainunit>().Select(null, null) on s.MainUnitID equals m.MainUnitID
                                   select new
                                   {
                                       SubUnitID = s.SubUnitID,
                                       SName = s.Name,
                                       MainUnitID = m.MainUnitID,
                                       MainUnitName = m.Name
                                   };
                    foreach (var item in subUnits)
                    {
                        SubUnitDto sDto = new SubUnitDto();
                        sDto.SubUnitID = item.SubUnitID;
                        sDto.Name = item.SName;
                        sDto.MainUnitID = item.MainUnitID;
                        sDto.MainUnitDto = new MainUnitDto();
                        sDto.MainUnitDto.MainUnitID = item.MainUnitID;
                        sDto.MainUnitDto.Name = item.MainUnitName;
                        sDtoList.Add(sDto);
                    }
                    return sDtoList;
                }
            }
            catch (Exception ex)
            {
                return new List<SubUnitDto>();
            }
        }
        public List<SubUnitDto> GetAllWithByMainUnitID(int mainUnitID)
        {
            try
            {
                List<SubUnitDto> sDtoList = new List<SubUnitDto>();
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var list = unitOfWork.GetRepository<subunit>().Select(null, null).Where(a => a.MainUnitID == mainUnitID).ToList();
                    foreach (var item in list)
                    {
                        SubUnitDto sDto = new SubUnitDto();
                        sDto.SubUnitID = item.SubUnitID;
                        sDto.MainUnitID = item.MainUnitID.Value;
                        sDto.Name = item.Name;
                        sDtoList.Add(sDto);
                    }
                    return sDtoList;
                }
            }
            catch (Exception ex)
            {
                return new List<SubUnitDto>();
            }
        }
        public bool IsThere(SubUnitDto subUnitDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<subunit>().GetById(x => x.Name.ToUpper() == subUnitDto.Name.ToUpper());
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
