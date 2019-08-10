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
    [ServiceContract(Namespace = "LocationApp.Service.Services.DepartmentRoomService")]
    public interface IDepartmentRoomService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/AddDepartmentRoom")]
        string AddDepartmentRoom(DepartmentRoomDto departmentRoomDto);

        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/SetDepartmentRoom")]
        string SetDepartmentRoom(DepartmentRoomDto departmentRoomDto);

        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetDepartmentRoom?departmentRoomID={departmentRoomID}")]
        string GetDepartmentRoom(int departmentRoomID);

        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/DelDepartmentRoom?departmentRoomID={departmentRoomID}")]
        string DelDepartmentRoom(int departmentRoomID);
    }
}
