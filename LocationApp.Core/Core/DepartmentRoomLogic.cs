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
    public class DepartmentRoomLogic
    {
        public ResultHelper AddDepartmentRoom(DepartmentRoomDto departmentRoomDto)
        {
            try
            {
                departmentroom item = new departmentroom();
                item.DepartmentID = departmentRoomDto.DepartmentID;
                item.DepartmentRoomID = departmentRoomDto.DepartmentRoomID;
                item.RoomID = departmentRoomDto.RoomID;
                item.Other = departmentRoomDto.Other;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<departmentroom>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.DepartmentRoomID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, departmentRoomDto.DepartmentRoomID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetDepartmentRoom(DepartmentRoomDto departmentRoomDto)
        {
            try
            {
                departmentroom item = new departmentroom();
                item.DepartmentID = departmentRoomDto.DepartmentID;
                item.DepartmentRoomID = departmentRoomDto.DepartmentRoomID;
                item.RoomID = departmentRoomDto.RoomID;
                item.Other = departmentRoomDto.Other;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<departmentroom>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.DepartmentRoomID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, departmentRoomDto.DepartmentRoomID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelDepartmentRoom(int departmentRoomId)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedDepartmentRoom = unitofWork.GetRepository<departmentroom>().GetById(x => x.DepartmentRoomID == departmentRoomId);
                    unitofWork.GetRepository<departmentroom>().Delete(selectedDepartmentRoom);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, departmentRoomId, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, departmentRoomId, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public DepartmentRoomDto GetDepartmentRoom(int departmentRoomID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    departmentroom item = new departmentroom();
                    item = unitofWork.GetRepository<departmentroom>().GetById(x => x.DepartmentRoomID == departmentRoomID);
                    DepartmentRoomDto departmentRoomDto = new DepartmentRoomDto();
                    departmentRoomDto.DepartmentID = (int)item.DepartmentID;
                    departmentRoomDto.DepartmentRoomID = item.DepartmentRoomID;
                    departmentRoomDto.Other = item.Other;
                    departmentRoomDto.RoomID = (int)item.RoomID;

                    return departmentRoomDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
