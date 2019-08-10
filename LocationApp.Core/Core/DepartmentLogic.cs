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
    public class DepartmentLogic
    {
        public ResultHelper AddDepartment(DepartmentDto departmentDto)
        {
            try
            {
                if (IsThere(departmentDto))
                    return new ResultHelper(false, departmentDto.DepartmentID, ResultHelper.IsThereItem);

                department item = new department();
                item.DepartmentID = departmentDto.DepartmentID;
                item.Description = departmentDto.Description;
                item.Other = departmentDto.Other;
                item.SubUnitID = departmentDto.SubUnitID;
                item.Name = departmentDto.Name;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<department>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.DepartmentID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, departmentDto.DepartmentID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetDepartment(DepartmentDto departmentDto)
        {
            try
            {
                department item = new department();
                item.DepartmentID = departmentDto.DepartmentID;
                item.Description = departmentDto.Description;
                item.Other = departmentDto.Other;
                item.SubUnitID = departmentDto.SubUnitID;
                
                item.Name = departmentDto.Name;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<department>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, departmentDto.DepartmentID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, departmentDto.DepartmentID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelDepartment(int departmentID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedDeparment = unitofWork.GetRepository<department>().GetById(x => x.DepartmentID == departmentID);
                    unitofWork.GetRepository<department>().Delete(selectedDeparment);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, departmentID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, departmentID, ResultHelper.UnSuccessMessage+" "+ResultHelper.DontDeleted);
            }
        }
        public DepartmentDto GetDepartment(int departmentID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    department item = new department();
                    item = unitofWork.GetRepository<department>().GetById(x => x.DepartmentID == departmentID);
                    DepartmentDto departmentDto = new DepartmentDto();
                    departmentDto.DepartmentID = item.DepartmentID;
                    departmentDto.SubUnitID = (int)item.SubUnitID;
                    departmentDto.Name = item.Name;
                    departmentDto.Description = item.Description;
                    departmentDto.Other = item.Other;
                    departmentDto.DepartmentRoomDto = new DepartmentRoomDto();
                    var depRoomDto = unitofWork.GetRepository<departmentroom>().GetById(x => x.DepartmentID == departmentID);
                    if (depRoomDto != null)
                    {
                        departmentDto.DepartmentRoomDto.DepartmentRoomID = depRoomDto.DepartmentRoomID;
                        departmentDto.DepartmentRoomDto.DepartmentID = depRoomDto.DepartmentID.Value;
                        departmentDto.DepartmentRoomDto.RoomID = depRoomDto.RoomID.Value;
                    }
                    return departmentDto;
                }
            }
            catch (Exception ex)
            {
                return new DepartmentDto();
            }
        }
        public List<DepartmentDto> GetAllDepartment()
        {
            try
            {//TODO: Departman Çağırma Performans Çalışması
                List<DepartmentDto> deplist = new List<DepartmentDto>();
                using (var context = new locationappEntities())
                {
                    var departmentList = from d in context.departments
                                         join s in context.subunits on d.SubUnitID equals s.SubUnitID
                                         join m in context.mainunits on s.MainUnitID equals m.MainUnitID
                                         select new
                                         {
                                             DID = d.DepartmentID,
                                             DName = d.Name,
                                             DDesc = d.Description,
                                             DOther = d.Other,
                                             SID = s.SubUnitID,
                                             SName = s.Name,
                                             SMID = s.MainUnitID,
                                             MID = m.MainUnitID,
                                             MName = m.Name
                                         };

                    foreach (var item in departmentList)
                    {
                        DepartmentDto depDto = new DepartmentDto();
                        depDto.DepartmentID = item.DID;
                        depDto.Name = item.DName;
                        depDto.Other = item.DOther;
                        depDto.SubUnitID = item.SID;
                        depDto.Description = item.DDesc;
                        depDto.SubUnitDto = new SubUnitDto();
                        depDto.SubUnitDto.SubUnitID = item.SID;
                        depDto.SubUnitDto.Name = item.SName;
                        depDto.SubUnitDto.MainUnitDto = new MainUnitDto();
                        depDto.SubUnitDto.MainUnitID = item.SMID.Value;
                        depDto.SubUnitDto.MainUnitDto.Name = item.MName;
                        depDto.SubUnitDto.MainUnitDto.MainUnitID = item.MID;
                        deplist.Add(depDto);
                    }
                    return deplist;
                }
            }
            catch (Exception ex)
            {
                return new List<DepartmentDto>();
            }
        }
        public bool IsThere(DepartmentDto departmentDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<department>().GetById(x => x.Name.ToUpper() == departmentDto.Name.ToUpper());
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
