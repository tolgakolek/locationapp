using LocationApp.Core.Helper;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApp.Data.Database;

namespace LocationApp.Core.Core
{
    public class DeviceLogic
    {
        public ResultHelper AddDevice(DeviceDto deviceDto)
        {
            try
            {

                device item = new device();
                item.Name = deviceDto.Name;
                item.DeviceTypeID = deviceDto.DeviceTypeID;
                item.Properties = deviceDto.Properties;
                item.Technology = deviceDto.Technology;
                item.DeviceTypeID = deviceDto.DeviceTypeID;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<device>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.DeviceID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetDevice(DeviceDto deviceDto)
        {
            try
            {

                device item = new device();
                item.DeviceID = deviceDto.DeviceID;
                item.Name = deviceDto.Name;
                item.DeviceTypeID = deviceDto.DeviceTypeID;
                item.Properties = deviceDto.Properties;
                item.Technology = deviceDto.Technology;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<device>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.DeviceID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public DeviceDto GetDevice(int deviceID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    device item = new device();
                    item = unitofWork.GetRepository<device>().GetById(x => x.DeviceID == deviceID);
                    DeviceDto deviceDto = new DeviceDto();
                    deviceDto.DeviceID = item.DeviceID;
                    deviceDto.DeviceTypeID = item.DeviceTypeID.Value;
                    deviceDto.Name = item.Name;
                    deviceDto.Properties = item.Properties;
                    deviceDto.Technology = item.Technology;

                    return deviceDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<DeviceDto> GetAllDevices()
        {
            try
            {
                List<DeviceDto> deviceList = new List<DeviceDto>();

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var list = from dev in unitOfWork.GetRepository<device>().Select(null, null)
                               join deviceType in unitOfWork.GetRepository<devicetype>().Select(null, null) on dev.DeviceTypeID equals deviceType.DeviceTypeID
                               select new
                               {
                                   DeviceID = dev.DeviceID,
                                   Name = dev.Name,
                                   Technology = dev.Technology,
                                   Properties = dev.Properties,
                                   TypeID = dev.DeviceTypeID,
                                   TName = deviceType.Name
                               };
                    foreach (var item in list)
                    {
                        DeviceDto deviceDto = new DeviceDto();
                        deviceDto.DeviceID = item.DeviceID;
                        deviceDto.DeviceTypeID = item.TypeID.Value;
                        deviceDto.Name = item.Name;
                        deviceDto.Properties = item.Properties;
                        deviceDto.Technology = item.Technology;
                        deviceDto.DeviceTypeDto = new DeviceTypeDto();
                        deviceDto.DeviceTypeDto.DeviceTypeID = item.TypeID.Value;
                        deviceDto.DeviceTypeDto.Name = item.TName;
                        deviceList.Add(deviceDto);
                    }
                    return deviceList;
                }
            }
            catch (Exception ex)
            {
                return new List<DeviceDto>();
            }
        }
        public ResultHelper DelDevice(int deviceID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedDevice = unitofWork.GetRepository<device>().GetById(x => x.DeviceID == deviceID);
                    unitofWork.GetRepository<device>().Delete(selectedDevice);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, deviceID, ResultHelper.SuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, deviceID, ResultHelper.UnSuccessMessage);
            }
        }
        public List<DeviceDto> GetAllDeviceWithRoomAndUser()
        {
            try
            {
                List<DeviceDto> deviceList = new List<DeviceDto>();
                using (var context = new locationappEntities())
                {
                    var query = from d in context.devices
                                join dt in context.devicetypes on d.DeviceTypeID equals dt.DeviceTypeID
                                join dr in context.devicerooms on d.DeviceID equals dr.DeviceID into deviceroom
                                from dr in deviceroom.DefaultIfEmpty()
                                join r in context.rooms on dr.RoomID equals r.RoomID into room
                                from r in room.DefaultIfEmpty()
                                join du in context.deviceusers on d.DeviceID equals du.DeviceID into deviceuser
                                from du in deviceuser.DefaultIfEmpty()
                                join u in context.users on du.UserID equals u.UserID into user
                                from u in user.DefaultIfEmpty()
                                select new
                                {
                                    DeviceID = d.DeviceID,
                                    DeviceName = d.Name,
                                    TypeName = dt.Name,
                                    TypeID = dt.DeviceTypeID,
                                    Properties = d.Properties,
                                    Technology = d.Technology,
                                    DeviceRoomID = dr == null ? 0 : dr.DeviceRoomID,
                                    RoomID = r == null ? 0 : r.RoomID,
                                    RName = r == null ? "(-)" : r.Name,
                                    DFLocationx = dr == null ? "(-)" : dr.LocationX,
                                    DFLocationy = dr == null ? "(-)" : dr.LocationX,
                                    DFCreationDate = dr == null ? null : dr.CreationDate,
                                    UserID = u == null ? 0 : u.UserID,
                                    UserFullName = u == null ? "(-)" : u.Name + " " + u.SurName,
                                    DevUserID = du == null ? 0 : du.DeviceUserID
                                };

                    foreach (var item in query)
                    {
                        DeviceDto deviceDto = new DeviceDto();
                        deviceDto.DeviceID = item.DeviceID;
                        deviceDto.Name = item.DeviceName;
                        deviceDto.Properties = item.Properties;
                        deviceDto.Technology = item.Technology;
                        deviceDto.DeviceTypeDto = new DeviceTypeDto();
                        deviceDto.DeviceTypeDto.DeviceTypeID = item.TypeID;
                        deviceDto.DeviceTypeDto.Name = item.TypeName;
                        deviceDto.RoomDto = new RoomDto();
                        deviceDto.RoomDto.RoomID = item.RoomID;
                        deviceDto.RoomDto.Name = item.RName;
                        deviceDto.DeviceRoomDto = new DeviceRoomDto();
                        deviceDto.DeviceRoomDto.DeviceRoomID = item.DeviceRoomID;
                        deviceDto.DeviceRoomDto.DeviceID = item.DeviceID;
                        deviceDto.DeviceRoomDto.Location_X = item.DFLocationx;
                        deviceDto.DeviceRoomDto.Location_Y = item.DFLocationy;
                        deviceDto.DeviceRoomDto.CreationDate = item.DFCreationDate.Value;
                        deviceList.Add(deviceDto);

                    }
                    return deviceList;
                }
            }
            catch (Exception ex)
            {
                return new List<DeviceDto>();
            }
        }

    }
}
