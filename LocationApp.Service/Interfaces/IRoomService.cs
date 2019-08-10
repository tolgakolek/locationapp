using LocationApp.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LocationApp.Service.Interfaces
{
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "AddRoom")]
        string AddRoom(RoomDto roomDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "SetRoom")]
        string SetRoom(RoomDto roomDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "DelRoom?roomID={roomID}")]
        string DelRoom(int roomID);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "GetRoom?roomID={roomID}")]
        string GetRoom(int roomID);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllRoom")]
        string GetAllRoom();
    }
}
