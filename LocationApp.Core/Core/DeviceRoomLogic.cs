using LocationApp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApp.Data.Dto;
using LocationApp.Data.Database;
using LocationApp.Data.UnitOfWork;

namespace LocationApp.Core.Core
{
    public class DeviceRoomLogic
    {
        public ResultHelper AddDeviceRoom(DeviceRoomDto deviceRoomDto)
        {
            try
            {
                deviceroom item = new deviceroom();
                item.DeviceRoomID = deviceRoomDto.DeviceRoomID;
                item.DeviceID = deviceRoomDto.DeviceID;
                item.CreationDate = deviceRoomDto.CreationDate;
                item.RoomID = deviceRoomDto.RoomID;
                item.LocationX = deviceRoomDto.Location_X;
                item.LocationY = deviceRoomDto.Location_Y;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<deviceroom>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.DeviceRoomID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetDeviceRoom(DeviceRoomDto deviceRoomDto)
        {
            try
            {
                deviceroom item = new deviceroom();
                item.DeviceRoomID = deviceRoomDto.DeviceRoomID;
                item.DeviceID = deviceRoomDto.DeviceID;
                item.CreationDate = deviceRoomDto.CreationDate;
                item.RoomID = deviceRoomDto.RoomID;
                item.LocationX = deviceRoomDto.Location_X;
                item.LocationY = deviceRoomDto.Location_Y;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<deviceroom>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.DeviceRoomID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelDeviceRoom(int deviceroomID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selecteddeviceroom = unitofWork.GetRepository<deviceroom>().GetById(x => x.DeviceRoomID == deviceroomID);
                    unitofWork.GetRepository<deviceroom>().Delete(selecteddeviceroom);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, deviceroomID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, deviceroomID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public DeviceRoomDto GetDeviceRoom(int deviceroomID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    deviceroom item = new deviceroom();
                    item = unitofWork.GetRepository<deviceroom>().GetById(x => x.DeviceRoomID == deviceroomID);
                    DeviceRoomDto deviceRoomDto = new DeviceRoomDto();
                    deviceRoomDto.DeviceID = item.DeviceID.Value;
                    deviceRoomDto.Location_X = item.LocationX;
                    deviceRoomDto.Location_Y = item.LocationY;
                    deviceRoomDto.CreationDate = item.CreationDate.Value;
                    deviceRoomDto.RoomID = item.RoomID.Value;

                    return deviceRoomDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<DeviceRoomDto> GetAllDeviceRoom()
        {
            try
            {
                List<DeviceRoomDto> list = new List<DeviceRoomDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var query = (from dr in unitofWork.GetRepository<deviceroom>().Select(null, null)
                                 join r in unitofWork.GetRepository<room>().Select(null, null) on dr.RoomID equals r.RoomID
                                 join d in unitofWork.GetRepository<device>().Select(null, null) on dr.DeviceID equals d.DeviceID
                                 select new
                                 {
                                     dRoomID = dr.DeviceRoomID,
                                     Location_X=dr.LocationX,
                                     Location_Y=dr.LocationY,
                                     RoomID=r.RoomID,
                                     RName = r.Name,
                                     DeviceID=d.DeviceID,
                                     DName=d.Name
                                 });
                    foreach (var item in query)
                    {
                        DeviceRoomDto deviceRoomDto = new DeviceRoomDto();
                        deviceRoomDto.DeviceRoomID = item.dRoomID;
                        deviceRoomDto.RoomDto = new RoomDto();
                        deviceRoomDto.RoomID = item.RoomID;
                        deviceRoomDto.RoomDto.Name = item.RName;
                        deviceRoomDto.DeviceDto = new DeviceDto();
                        deviceRoomDto.DeviceID = item.DeviceID;
                        deviceRoomDto.DeviceDto.Name = item.DName;
                        deviceRoomDto.Location_X = item.Location_X;
                        deviceRoomDto.Location_Y = item.Location_Y;
                        list.Add(deviceRoomDto);
                    }
                    return list;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
