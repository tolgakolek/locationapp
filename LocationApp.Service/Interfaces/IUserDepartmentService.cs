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
    [ServiceContract(Namespace = "LocationApp.Service.Services.UserDepartmentService")]
    public interface IUserDepartmentService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddUserDepartment")]
        string AddUserDepartment(UserDepartmentDto userDepartmentDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "SetUserDepartment")]
        string SetUserDepartment(UserDepartmentDto userDepartmentDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DelUserDepartment?userDepartmentID={userDepartmentID}")]
        string DelUserDepartment(int userDepartmentID);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUserDepartment?userDepartmentID={userDepartmentID}")]
        string GetUserDepartment(int userDepartmentID);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetAllUserDepartment")]
        string GetAllUserDepartment();

    }
}