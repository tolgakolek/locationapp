using LocationApp.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApp.Data;
using System.ServiceModel.Web;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using System.Net;
using LocationApp.Core.Helper;

namespace LocationApp.Core.Core
{
    public class RoomTypeLogic
    {
        public ResultHelper AddRoomType(RoomTypeDto roomTypeDto)
        {
            try
            {
                if (IsThere(roomTypeDto))
                    return new ResultHelper(false, roomTypeDto.RoomTypeID, ResultHelper.IsThereItem);

                roomtype item = new roomtype();
                item.RoomTypeID = roomTypeDto.RoomTypeID;
                item.Name = roomTypeDto.Name;
                item.Description = roomTypeDto.Description;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<roomtype>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.RoomTypeID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, roomTypeDto.RoomTypeID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetRoomType(RoomTypeDto roomTypeDto)
        {
            try
            {
                roomtype item = new roomtype();
                item.RoomTypeID = roomTypeDto.RoomTypeID;
                item.Name = roomTypeDto.Name;
                item.Description = roomTypeDto.Description;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<roomtype>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, roomTypeDto.RoomTypeID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, roomTypeDto.RoomTypeID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelRoomType(int roomTypeID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedRoomType = unitofWork.GetRepository<roomtype>().GetById(x => x.RoomTypeID == roomTypeID);
                    unitofWork.GetRepository<roomtype>().Delete(selectedRoomType);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, roomTypeID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, roomTypeID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public RoomTypeDto GetRoomType(int roomTypeID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    roomtype item = new roomtype();
                    item = unitofWork.GetRepository<roomtype>().GetById(x => x.RoomTypeID == roomTypeID);
                    RoomTypeDto roomTypeDto = new RoomTypeDto();
                    roomTypeDto.Name = item.Name;
                    roomTypeDto.RoomTypeID = item.RoomTypeID;
                    roomTypeDto.Description = item.Description;

                    return roomTypeDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<RoomTypeDto> GetAllRoomType()
        {
            try
            {
                List<RoomTypeDto> list = new List<RoomTypeDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<roomtype> collection = unitofWork.GetRepository<roomtype>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new RoomTypeDto {RoomTypeID=item.RoomTypeID,Name=item.Name,Description=item.Description });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<RoomTypeDto>();
            }
        }
        public bool IsThere(RoomTypeDto roomTypeDto)
        {
            using (UnitOfWork unitofWork = new UnitOfWork())
            {
                var item = unitofWork.GetRepository<roomtype>().GetById(x => x.Name.ToUpper() == roomTypeDto.Name.ToUpper());
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
