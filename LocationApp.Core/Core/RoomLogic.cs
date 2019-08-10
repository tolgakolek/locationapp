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
    public class RoomLogic
    {
        public ResultHelper AddRoom(RoomDto roomDto)
        {
            try
            {
                room item = new room();
                item.FloorID = roomDto.FloorID;
                item.Map = roomDto.Map;
                item.Name = roomDto.Name;
                item.RoomID = roomDto.RoomID;
                item.RoomTypeID = roomDto.RoomTypeID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<room>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.RoomID, ResultHelper.SuccessMessage);

                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, roomDto.RoomID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetRoom(RoomDto roomDto)
        {
            try
            {
                room item = new room();
                item.FloorID = roomDto.FloorID;
                if (string.IsNullOrEmpty(roomDto.Map))
                    item.Map = roomDto.Map;
                item.Name = roomDto.Name;
                item.RoomID = roomDto.RoomID;
                item.RoomTypeID = roomDto.RoomTypeID;
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<room>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, roomDto.RoomID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, roomDto.RoomID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelRoom(int roomID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedRoom = unitofWork.GetRepository<room>().GetById(x => x.RoomID == roomID);
                    unitofWork.GetRepository<room>().Delete(selectedRoom);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, roomID, ResultHelper.SuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, roomID, ResultHelper.UnSuccessMessage);
            }
        }
        public RoomDto GetRoom(int roomID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    room item = new room();
                    item = unitofWork.GetRepository<room>().GetById(x => x.RoomID == roomID);
                    RoomDto roomDto = new RoomDto();
                    roomDto.FloorID = (int)item.FloorID;
                    roomDto.RoomID = item.RoomID;
                    roomDto.RoomTypeID = (int)item.RoomTypeID;
                    roomDto.Name = item.Name;
                    roomDto.Map = item.Map;

                    //Oda kat bilgisi
                    var floor = unitofWork.GetRepository<floor>().GetById(x => x.FloorID == roomDto.FloorID);
                    if (floor.BuildID != 0)
                    {
                        var itemBuild = unitofWork.GetRepository<build>().GetById(x => x.BuildID == floor.BuildID);
                        roomDto.BuildDto = new BuildDto();
                        roomDto.BuildDto.BuildID = itemBuild.BuildID;
                        roomDto.BuildDto.Name = itemBuild.Name;
                    }
                    if (floor.BlockID != 0)
                    {
                        var itemBlock = unitofWork.GetRepository<block>().GetById(x => x.BlockID == floor.BlockID);
                        roomDto.BlockDto = new BlockDto();
                        roomDto.BlockDto.BlockID = itemBlock.BlockID;
                        roomDto.BlockDto.Name = itemBlock.Name;
                    }

                    //DepartmaRoom İlişki Tablosu
                    var departmentRoom = unitofWork.GetRepository<departmentroom>().GetById(x => x.RoomID == roomDto.RoomID);
                    roomDto.DepartmentRoomDto = new DepartmentRoomDto();
                    roomDto.DepartmentRoomDto.DepartmentRoomID = departmentRoom.DepartmentRoomID;
                    roomDto.DepartmentRoomDto.DepartmentID = departmentRoom.DepartmentID.Value;
                    roomDto.DepartmentRoomDto.RoomID = departmentRoom.RoomID.Value;
                    //Departman Bilgileri
                    var department = unitofWork.GetRepository<department>().GetById(x => x.DepartmentID == roomDto.DepartmentRoomDto.DepartmentID);
                    roomDto.DepartmentDto = new DepartmentDto();
                    roomDto.DepartmentDto.DepartmentID = department.DepartmentID;
                    roomDto.DepartmentDto.Name = department.Name;


                    return roomDto;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<RoomDto> GetAllRooms()
        {
            try
            {
                List<RoomDto> roomList = new List<RoomDto>();

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var list = from room in unitOfWork.GetRepository<room>().Select(null, null)
                               join depRoom in unitOfWork.GetRepository<departmentroom>().Select(null, null) on room.RoomID equals depRoom.RoomID
                               join dep in unitOfWork.GetRepository<department>().Select(null, null) on depRoom.DepartmentID equals dep.DepartmentID
                               join floor in unitOfWork.GetRepository<floor>().Select(null, null) on room.FloorID equals floor.FloorID
                               select new
                               {
                                   RoomID = room.RoomID,//Room
                                   FloorID = room.FloorID,
                                   RTypeID = room.RoomTypeID,
                                   Name = room.Name,
                                   Map = room.Map,
                                   DPID = depRoom.DepartmentRoomID,//DepartmetnRoom
                                   DPDepID = depRoom.DepartmentID,
                                   DPRoomID = depRoom.RoomID,
                                   DepID = dep.DepartmentID,
                                   DName = dep.Name,//Department
                                   DDesc = dep.Description,
                                   Dother = dep.Other,
                                   FName = floor.Name,//Floor
                               };
                    foreach (var item in list)
                    {
                        RoomDto rDto = new RoomDto();
                        rDto.RoomID = item.RoomID;
                        rDto.FloorID = item.FloorID.Value;
                        rDto.RoomTypeID = item.RTypeID.Value;
                        rDto.Name = item.Name;
                        rDto.Map = item.Map;
                        //Departman Oda İlişki
                        rDto.DepartmentRoomDto = new DepartmentRoomDto();
                        rDto.DepartmentRoomDto.DepartmentID = item.DPDepID.Value;
                        rDto.DepartmentRoomDto.DepartmentRoomID = item.DPRoomID.Value;
                        rDto.DepartmentRoomDto.RoomID = item.RoomID;
                        //Departman
                        rDto.DepartmentDto = new DepartmentDto();
                        rDto.DepartmentDto.DepartmentID = item.DepID;
                        rDto.DepartmentDto.Name = item.DName;
                        rDto.DepartmentDto.Other = item.Dother;
                        //Kat
                        rDto.FloorDto = new FloorDto();
                        rDto.FloorDto.FloorID = item.FloorID.Value;
                        rDto.FloorDto.Name = item.FName;
                        roomList.Add(rDto);
                    }
                    return roomList;
                }
            }
            catch (Exception ex)
            {
                return new List<RoomDto>();
            }
        }
    }
}
