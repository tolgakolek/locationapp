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
    [ServiceContract(Namespace = "LocationApp.Service.Services.DepartmentService")]
    public interface IDepartmentService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "AddDepartment")]
        string AddDepartment(DepartmentDto departmentDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SetDepartment")]
        string SetDepartment(DepartmentDto departmentDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DelDepartment?departmentID={departmentID}")]
        string DelDepartment(int departmentID);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetDepartment?departmentID={departmentID}")]
        string GetDepartment(int departmentID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllDepartment")]
        string GetAllDepartment();
    }
}
