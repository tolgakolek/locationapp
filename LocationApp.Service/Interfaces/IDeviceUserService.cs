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
    [ServiceContract]
    public interface IDeviceUserService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddDeviceUser")]
        string AddDeviceUser(DeviceUserDto deviceUserDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SetDeviceUser")]
        string SetDeviceUser(DeviceUserDto deviceUserDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DelDeviceUser?deviceUserID={deviceUserID}")]
        string DelDeviceUser(int deviceUserID);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetDeviceUser?deviceUserID={deviceUserID}")]
        string GetDeviceUser(int deviceUserID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAllDeviceUser")]
        string GetAllDeviceUser();
    }
}
