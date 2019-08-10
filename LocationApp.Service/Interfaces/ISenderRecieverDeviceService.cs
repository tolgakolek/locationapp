using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LocationApp.Data.Dto;

namespace LocationApp.Service.Interfaces
{
    [ServiceContract(Namespace = "LocationApp.Service.Services.SenderRecieverDeviceService")]
    public interface ISenderRecieverDeviceService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "SetMobilBeacon")]
        string SetMobilBeacon(SenderRecieverDeviceMobilBeaconDto data);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "SetMobilWifi")]

        string SetMobilWifi(List<SenderRecieverDeviceMobilWifiDto> data);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "SetNodemcuWifi")]
        string SetNodemcuWifi(List<SenderRecieverDeviceNodemcuWifiDto> data);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "SetRaspberryBeacon")]
        string SetRaspberryBeacon(List<SenderRecieverDeviceRaspberryBeaconDto> data);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "GetDeviceRaspBerryBeaconList")]
        string GetDeviceRaspBerryBeaconList();
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "GetMobilWifiList")]
        string GetMobilWifiList();
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "GetDeviceNodemcuWifiList")]
        string GetDeviceNodemcuWifiList();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "GetMobilBeaconList")]
        string GetMobilBeaconList();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "GetDateNodemMcuBeacon")]
        string GetDateNodemMcuBeacon(DateTime startDate, DateTime endDate);
    }
}
