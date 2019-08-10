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
    [ServiceContract(Namespace = "LocationApp.Service.Services.DeviceService")]
    public interface IDeviceService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddDevice")]
        string AddDevice(DeviceDto deviceDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SetDevice")]
        string SetDevice(DeviceDto deviceDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DelDevice?deviceID={deviceID}")]
        string DelDevice(int deviceID);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetDevice?deviceID={deviceID}")]
        string GetDevice(int deviceID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAllDevice")]
        string GetAllDevice();
    }
}
