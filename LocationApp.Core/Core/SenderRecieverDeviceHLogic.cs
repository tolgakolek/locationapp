using LocationApp.Core.Helper;
using LocationApp.Data.Database;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Core.Core
{
    public class SenderRecieverDeviceHLogic
    {
        public string SetMobilBeacon(SenderRecieverDeviceMobilBeaconDto data)
        {
            try
            {
                senderrecieverdevicemobilbeacon mobilBeacon = new senderrecieverdevicemobilbeacon();
                mobilBeacon.ID = 0;
                mobilBeacon.DeviceID = data.DeviceID; ;
                mobilBeacon.CreationDate = data.CreationDate;
                mobilBeacon.Counter = data.Counter;
                mobilBeacon.Device_Name_1 = data.Device_Name_1;
                mobilBeacon.Device_Name_2 = data.Device_Name_2;
                mobilBeacon.Device_Name_3 = data.Device_Name_3;
                mobilBeacon.Device_Name_4 = data.Device_Name_4;
                mobilBeacon.Device_Name_5 = data.Device_Name_5;
                mobilBeacon.Device_Name_6 = data.Device_Name_6;
                mobilBeacon.Device_Distance_1 = data.Device_Distance_1;
                mobilBeacon.Device_Distance_2 = data.Device_Distance_2;
                mobilBeacon.Device_Distance_3 = data.Device_Distance_3;
                mobilBeacon.Device_Distance_4 = data.Device_Distance_4;
                mobilBeacon.Device_Distance_5 = data.Device_Distance_5;
                mobilBeacon.Device_Distance_6 = data.Device_Distance_6;
                mobilBeacon.Device_RSS_1 = data.Device_RSS_1;
                mobilBeacon.Device_RSS_2 = data.Device_RSS_2;
                mobilBeacon.Device_RSS_3 = data.Device_RSS_3;
                mobilBeacon.Device_RSS_4 = data.Device_RSS_4;
                mobilBeacon.Device_RSS_5 = data.Device_RSS_5;
                mobilBeacon.Device_RSS_6 = data.Device_RSS_6;
                mobilBeacon.Point_Location = data.Point_Location;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<senderrecieverdevicemobilbeacon>().Insert(mobilBeacon);
                    unitOfWork.saveChanges();
                    return ResultHelper.SuccessMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string SetMobilWifi(List<SenderRecieverDeviceMobilWifiDto> data)
        {
            try
            {
                senderrecieverdevicemobilwifi mobilWifi = null;
                foreach (var item in data)
                {
                    mobilWifi = new senderrecieverdevicemobilwifi();
                    mobilWifi.ID = 0;
                    mobilWifi.DeviceID = item.DeviceID;
                    mobilWifi.CreationDate = item.CreationDate;
                    mobilWifi.Device_Name_1 = item.Device_Name_1;
                    mobilWifi.Device_Name_2 = item.Device_Name_2;
                    mobilWifi.Device_Name_3 = item.Device_Name_3;
                    mobilWifi.Device_Name_4 = item.Device_Name_4;
                    mobilWifi.Device_Name_5 = item.Device_Name_5;
                    mobilWifi.Device_Name_6 = item.Device_Name_6;
                    mobilWifi.Device_Distance_1 = item.Device_Distance_1;
                    mobilWifi.Device_Distance_2 = item.Device_Distance_2;
                    mobilWifi.Device_Distance_3 = item.Device_Distance_3;
                    mobilWifi.Device_Distance_4 = item.Device_Distance_4;
                    mobilWifi.Device_Distance_5 = item.Device_Distance_5;
                    mobilWifi.Device_Distance_6 = item.Device_Distance_6;
                    mobilWifi.Device_RSS_1 = item.Device_RSS_1;
                    mobilWifi.Device_RSS_2 = item.Device_RSS_2;
                    mobilWifi.Device_RSS_3 = item.Device_RSS_3;
                    mobilWifi.Device_RSS_4 = item.Device_RSS_4;
                    mobilWifi.Device_RSS_5 = item.Device_RSS_5;
                    mobilWifi.Device_RSS_6 = item.Device_RSS_6;
                    mobilWifi.Point_Location = item.Point_Location;
                }


                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<senderrecieverdevicemobilwifi>().Insert(mobilWifi);
                    unitOfWork.saveChanges();
                    return ResultHelper.SuccessMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                return ResultHelper.UnSuccessMessage.ToString();
            }
        }
        public string SetNodemcuWifi(List<SenderRecieverDeviceNodemcuWifiDto> data)
        {
            try
            {
                senderrecieverdevicenodemcuwifi nodemcuWifi = null;
                foreach (var item in data)
                {
                    nodemcuWifi = new senderrecieverdevicenodemcuwifi();
                    nodemcuWifi.ID = 0;
                    nodemcuWifi.DeviceID = item.DeviceID; ;
                    nodemcuWifi.CreationDate = item.CreationDate;
                    nodemcuWifi.Device_Name_1 = item.Device_Name_1;
                    nodemcuWifi.Device_Name_2 = item.Device_Name_2;
                    nodemcuWifi.Device_Name_3 = item.Device_Name_3;
                    nodemcuWifi.Device_Name_4 = item.Device_Name_4;
                    nodemcuWifi.Device_Distance_1 = item.Device_Distance_1;
                    nodemcuWifi.Device_Distance_2 = item.Device_Distance_2;
                    nodemcuWifi.Device_Distance_3 = item.Device_Distance_3;
                    nodemcuWifi.Device_Distance_4 = item.Device_Distance_4;
                    nodemcuWifi.Device_RSS_1 = item.Device_RSS_1;
                    nodemcuWifi.Device_RSS_2 = item.Device_RSS_2;
                    nodemcuWifi.Device_RSS_3 = item.Device_RSS_3;
                    nodemcuWifi.Device_RSS_4 = item.Device_RSS_4;
                    nodemcuWifi.Point_Location = item.Point_Location;
                }

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<senderrecieverdevicenodemcuwifi>().Insert(nodemcuWifi);
                    unitOfWork.saveChanges();
                    return ResultHelper.SuccessMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                return ResultHelper.UnSuccessMessage.ToString();
            }
        }
        public string SetRaspBeacon(List<SenderRecieverDeviceRaspberryBeaconDto> data)
        {
            try
            {
                senderrecieverdeviceraspberrybeacon raspBeacon = null;
                foreach (var item in data)
                {
                    raspBeacon = new senderrecieverdeviceraspberrybeacon();
                    raspBeacon.ID = 0;
                    raspBeacon.DeviceID = item.DeviceID; ;
                    raspBeacon.CreationDate = item.CreationDate;
                    raspBeacon.Counter = item.Counter;
                    raspBeacon.Device_Name_1 = item.Device_Name_1;
                    raspBeacon.Device_Name_2 = item.Device_Name_2;
                    raspBeacon.Device_Name_3 = item.Device_Name_3;
                    raspBeacon.Device_Name_4 = item.Device_Name_4;
                    raspBeacon.Device_Name_5 = item.Device_Name_5;
                    raspBeacon.Device_Name_6 = item.Device_Name_6;
                    raspBeacon.Device_Distance_1 = item.Device_Distance_1;
                    raspBeacon.Device_Distance_2 = item.Device_Distance_2;
                    raspBeacon.Device_Distance_3 = item.Device_Distance_3;
                    raspBeacon.Device_Distance_4 = item.Device_Distance_4;
                    raspBeacon.Device_Distance_5 = item.Device_Distance_5;
                    raspBeacon.Device_Distance_6 = item.Device_Distance_6;
                    raspBeacon.Device_RSS_1 = item.Device_RSS_1;
                    raspBeacon.Device_RSS_2 = item.Device_RSS_2;
                    raspBeacon.Device_RSS_3 = item.Device_RSS_3;
                    raspBeacon.Device_RSS_4 = item.Device_RSS_4;
                    raspBeacon.Device_RSS_5 = item.Device_RSS_5;
                    raspBeacon.Device_RSS_6 = item.Device_RSS_6;
                    raspBeacon.Point_Location = item.Point_Location;
                }

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<senderrecieverdeviceraspberrybeacon>().Insert(raspBeacon);
                    unitOfWork.saveChanges();
                    return ResultHelper.SuccessMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                return ResultHelper.UnSuccessMessage.ToString();
            }
        }
        public List<SenderRecieverDeviceRaspberryBeaconDto> GetDeviceRaspBerryBeaconList()
        {
            try
            {
                List<SenderRecieverDeviceRaspberryBeaconDto> list = new List<SenderRecieverDeviceRaspberryBeaconDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<senderrecieverdeviceraspberrybeacon> collection = unitofWork.GetRepository<senderrecieverdeviceraspberrybeacon>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new SenderRecieverDeviceRaspberryBeaconDto
                        {
                            ID = item.ID,
                            DeviceID = item.DeviceID,
                            Device_Name_1 = item.Device_Name_1,
                            Device_Name_2 = item.Device_Name_2,
                            Device_Name_3 = item.Device_Name_3,
                            Device_Name_4 = item.Device_Name_4,
                            Device_Distance_1 = item.Device_Distance_1,
                            Device_Distance_2 = item.Device_Distance_2,
                            Device_Distance_3 = item.Device_Distance_3,
                            Device_Distance_4 = item.Device_Distance_4,
                            Device_RSS_1 = item.Device_RSS_1,
                            Device_RSS_2 = item.Device_RSS_2,
                            Device_RSS_3 = item.Device_RSS_3,
                            Device_RSS_4 = item.Device_RSS_4,
                            //CreationDate = item.CreationDate,
                            Point_Location = item.Point_Location
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<SenderRecieverDeviceRaspberryBeaconDto>();
            }
        }
        public List<SenderRecieverDeviceMobilWifiDto> GetMobilWifiList()
        {
            try
            {
                List<SenderRecieverDeviceMobilWifiDto> list = new List<SenderRecieverDeviceMobilWifiDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<senderrecieverdevicemobilwifi> collection = unitofWork.GetRepository<senderrecieverdevicemobilwifi>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new SenderRecieverDeviceMobilWifiDto
                        {
                            ID = item.ID,
                            DeviceID = item.DeviceID,
                            Device_Name_1 = item.Device_Name_1,
                            Device_Name_2 = item.Device_Name_2,
                            Device_Name_3 = item.Device_Name_3,
                            Device_Name_4 = item.Device_Name_4,
                            Device_Name_5 = item.Device_Name_5,
                            Device_Name_6 = item.Device_Name_6,
                            Device_Distance_1 = item.Device_Distance_1,
                            Device_Distance_2 = item.Device_Distance_2,
                            Device_Distance_3 = item.Device_Distance_3,
                            Device_Distance_4 = item.Device_Distance_4,
                            Device_Distance_5 = item.Device_Distance_5,
                            Device_Distance_6 = item.Device_Distance_6,
                            Device_RSS_1 = item.Device_RSS_1,
                            Device_RSS_2 = item.Device_RSS_2,
                            Device_RSS_3 = item.Device_RSS_3,
                            Device_RSS_4 = item.Device_RSS_4,
                            Device_RSS_5 = item.Device_RSS_5,
                            Device_RSS_6 = item.Device_RSS_6,
                            //CreationDate = item.CreationDate.Value,
                            Point_Location = item.Point_Location
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<SenderRecieverDeviceMobilWifiDto>();
            }
        }
        public List<SenderRecieverDeviceNodemcuWifiDto> GetDeviceNodemcuWifiList()
        {
            try
            {
                List<SenderRecieverDeviceNodemcuWifiDto> list = new List<SenderRecieverDeviceNodemcuWifiDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<senderrecieverdevicenodemcuwifi> collection = unitofWork.GetRepository<senderrecieverdevicenodemcuwifi>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new SenderRecieverDeviceNodemcuWifiDto
                        {
                            ID = item.ID,
                            DeviceID = item.DeviceID,
                            Device_Name_1 = item.Device_Name_1,
                            Device_Name_2 = item.Device_Name_2,
                            Device_Name_3 = item.Device_Name_3,
                            Device_Name_4 = item.Device_Name_4,
                            Device_Distance_1 = item.Device_Distance_1,
                            Device_Distance_2 = item.Device_Distance_2,
                            Device_Distance_3 = item.Device_Distance_3,
                            Device_Distance_4 = item.Device_Distance_4,
                            Device_RSS_1 = item.Device_RSS_1,
                            Device_RSS_2 = item.Device_RSS_2,
                            Device_RSS_3 = item.Device_RSS_3,
                            Device_RSS_4 = item.Device_RSS_4,
                            //CreationDate = item.CreationDate.Value,
                            Point_Location = item.Point_Location
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<SenderRecieverDeviceNodemcuWifiDto>();
            }
        }
        public List<SenderRecieverDeviceMobilBeaconDto> GetMobilBeaconList()
        {
            try
            {
                List<SenderRecieverDeviceMobilBeaconDto> list = new List<SenderRecieverDeviceMobilBeaconDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<senderrecieverdevicemobilbeacon> collection = unitofWork.GetRepository<senderrecieverdevicemobilbeacon>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        list.Add(new SenderRecieverDeviceMobilBeaconDto
                        {
                            ID = item.ID,
                            DeviceID = item.DeviceID,
                            Device_Name_1 = item.Device_Name_1,
                            Device_Name_2 = item.Device_Name_2,
                            Device_Name_3 = item.Device_Name_3,
                            Device_Name_4 = item.Device_Name_4,
                            Device_Distance_1 = item.Device_Distance_1,
                            Device_Distance_2 = item.Device_Distance_2,
                            Device_Distance_3 = item.Device_Distance_3,
                            Device_Distance_4 = item.Device_Distance_4,
                            Device_RSS_1 = item.Device_RSS_1,
                            Device_RSS_2 = item.Device_RSS_2,
                            Device_RSS_3 = item.Device_RSS_3,
                            Device_RSS_4 = item.Device_RSS_4,

                            Point_Location = item.Point_Location
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<SenderRecieverDeviceMobilBeaconDto>();
            }
        }
        public List<SenderRecieverDeviceRaspberryBeaconDto> GetDateNodemMcuBeacon(DateTime Start, DateTime End)
        {
            try
            {
                List<SenderRecieverDeviceRaspberryBeaconDto> list = new List<SenderRecieverDeviceRaspberryBeaconDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<senderrecieverdeviceraspberrybeacon> data = new List<senderrecieverdeviceraspberrybeacon>();
                    List<senderrecieverdeviceraspberrybeacon> collection = unitofWork.GetRepository<senderrecieverdeviceraspberrybeacon>().Select(null, null).ToList();
                    data = collection.Where(x => DateTime.Parse(x.CreationDate) >= Start && DateTime.Parse(x.CreationDate) <= End).ToList();
                    foreach (var item in data)
                    {
                        list.Add(new SenderRecieverDeviceRaspberryBeaconDto
                        {
                            ID = item.ID,
                            Device_Name_1 = item.Device_Name_1,
                            Device_Name_2 = item.Device_Name_2,
                            Device_Name_3 = item.Device_Name_3,
                            Device_Name_4 = item.Device_Name_4,
                            Device_Name_5 = item.Device_Name_5,
                            Device_Name_6 = item.Device_Name_6,
                            Device_Distance_1 = item.Device_Distance_1,
                            Device_Distance_2 = item.Device_Distance_2,
                            Device_Distance_3 = item.Device_Distance_3,
                            Device_Distance_4 = item.Device_Distance_4,
                            Device_Distance_5 = item.Device_Distance_5,
                            Device_Distance_6 = item.Device_Distance_6,
                            Device_RSS_1 = item.Device_RSS_1,
                            Device_RSS_2 = item.Device_RSS_2,
                            Device_RSS_3 = item.Device_RSS_3,
                            Device_RSS_4 = item.Device_RSS_4,
                            Device_RSS_5 = item.Device_RSS_5,
                            Device_RSS_6 = item.Device_RSS_6,
                            CreationDate = item.CreationDate,
                            Point_Location = item.Point_Location
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<SenderRecieverDeviceRaspberryBeaconDto>();
            }
        }


    }
}