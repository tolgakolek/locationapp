using LocationApp.Core.Core;
using LocationApp.Data.Dto;
using LocationApp.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LocationApp.Service.Services
{
    public class SenderRecieverDeviceService : ISenderRecieverDeviceService
    {
        public SenderRecieverDeviceHLogic senderRecieverDeviceServiceLogic = new SenderRecieverDeviceHLogic();

        public string SetMobilBeacon(SenderRecieverDeviceMobilBeaconDto data)
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.SetMobilBeacon(data)).ToString();
        }
        public string SetMobilWifi(List<SenderRecieverDeviceMobilWifiDto> data)
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.SetMobilWifi(data)).ToString();
        }
        public string SetNodemcuWifi(List<SenderRecieverDeviceNodemcuWifiDto> data)
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.SetNodemcuWifi(data)).ToString();
        }
        public string SetRaspberryBeacon(List<SenderRecieverDeviceRaspberryBeaconDto> data)
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.SetRaspBeacon(data)).ToString();
        }
        public string GetDeviceRaspBerryBeaconList()
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.GetDeviceRaspBerryBeaconList());
        }
        public string GetMobilWifiList()
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.GetMobilWifiList());

        }
        public string GetDeviceNodemcuWifiList()
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.GetDeviceNodemcuWifiList());

        }
        public string GetMobilBeaconList()
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.GetMobilBeaconList());
        }
        public string GetDateNodemMcuBeacon(DateTime startDate, DateTime endDate)
        {
            return JsonConvert.SerializeObject(senderRecieverDeviceServiceLogic.GetDateNodemMcuBeacon(startDate, endDate));
        }
    }
}
