using LocationApp.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApp.Data.Database;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;

namespace LocationApp.Core.Core
{
    public class DeviceUserLogic
    {
        public ResultHelper AddDeviceUser(DeviceUserDto deviceUserDto)
        {
            try
            {

                deviceuser item = new deviceuser();

                item.DeviceUserID = deviceUserDto.DeviceUserID;
                item.DeviceID = deviceUserDto.DeviceID;
                item.UserID = deviceUserDto.UserID;
           
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<deviceuser>().Insert(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.DeviceUserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetDeviceUser(DeviceUserDto deviceUserDto)
        {
            try
            {
                deviceuser item = new deviceuser();
                item.DeviceUserID = deviceUserDto.DeviceUserID;
                item.DeviceID = deviceUserDto.DeviceID;
                item.UserID = deviceUserDto.UserID;
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<deviceuser>().Update(item);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, item.DeviceUserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelDeviceUser(int deviceUserID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedDevice = unitofWork.GetRepository<deviceuser>().GetById(x => x.DeviceUserID == deviceUserID);
                    unitofWork.GetRepository<deviceuser>().Delete(selectedDevice);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, deviceUserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, deviceUserID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
            }
        }
        public DeviceUserDto GetDeviceUser(int deviceUserID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    deviceuser item = new deviceuser();
                    item = unitofWork.GetRepository<deviceuser>().GetById(x => x.DeviceUserID == deviceUserID);
                    DeviceUserDto deviceUserDto = new DeviceUserDto();
                    deviceUserDto.DeviceID = item.DeviceID.Value;
                    deviceUserDto.DeviceUserID = item.DeviceUserID;
                    deviceUserDto.UserID = item.UserID.Value;

                    return deviceUserDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<DeviceUserDto> GetAllDeviceUser()
        {
            try
            {
                List<DeviceUserDto> list = new List<DeviceUserDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var query = (from du in unitofWork.GetRepository<deviceuser>().Select(null, null)
                                 join u in unitofWork.GetRepository<user>().Select(null, null) on du.UserID equals u.UserID
                                 join d in unitofWork.GetRepository<device>().Select(null, null) on du.DeviceID equals d.DeviceID
                                 select new
                                 {
                                     dUserID = du.UserID,
                                     UserID = u.UserID,
                                     FullName=u.Name+" "+u.SurName,
                                     DeviceID = d.DeviceID,
                                     DName = d.Name
                                 });
                    foreach (var item in query)
                    {
                        DeviceUserDto deviceUserDto = new DeviceUserDto();
                        deviceUserDto.DeviceUserID = item.dUserID.Value;
                        deviceUserDto.UserDto = new UserDto();
                        deviceUserDto.UserID = item.UserID;
                        deviceUserDto.UserDto.FullName = item.FullName;
                        deviceUserDto.DeviceDto = new DeviceDto();
                        deviceUserDto.DeviceID = item.DeviceID;
                        deviceUserDto.DeviceDto.Name = item.DName;
                        list.Add(deviceUserDto);
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
