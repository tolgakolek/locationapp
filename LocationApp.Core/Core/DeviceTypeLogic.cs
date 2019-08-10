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
    public class DeviceTypeLogic
    {
        public ResultHelper AddDeviceType(DeviceTypeDto deviceTypeDto)
        {
            try
            {
                devicetype item = new devicetype();
                item.DeviceTypeID = deviceTypeDto.DeviceTypeID;
                item.Name = deviceTypeDto.Name;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<devicetype>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.DeviceTypeID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetDeviceType(DeviceTypeDto deviceTypeDto)
        {
            try
            {

                devicetype item = new devicetype();
                item.DeviceTypeID = deviceTypeDto.DeviceTypeID;
                item.Name = deviceTypeDto.Name;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<devicetype>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.DeviceTypeID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public DeviceTypeDto GetDeviceType(int deviceTypeID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    devicetype item = new devicetype();
                    item = unitofWork.GetRepository<devicetype>().GetById(x => x.DeviceTypeID == deviceTypeID);
                    DeviceTypeDto deviceTypeDto = new DeviceTypeDto();
                    deviceTypeDto.DeviceTypeID = item.DeviceTypeID;
                    deviceTypeDto.Name = item.Name;

                    return deviceTypeDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ResultHelper DelDeviceType(int deviceTypeID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedDeviceType = unitofWork.GetRepository<devicetype>().GetById(x => x.DeviceTypeID == deviceTypeID);
                    unitofWork.GetRepository<devicetype>().Delete(selectedDeviceType);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, deviceTypeID, ResultHelper.SuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, deviceTypeID, ResultHelper.UnSuccessMessage);
            }
        }
        public List<DeviceTypeDto> GetAllDeviceType()
        {
            try
            {
                List<DeviceTypeDto> list = new List<DeviceTypeDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<devicetype> collection = unitofWork.GetRepository<devicetype>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new DeviceTypeDto { DeviceTypeID = item.DeviceTypeID, Name = item.Name });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<DeviceTypeDto>();
            }
        }
    }
}
