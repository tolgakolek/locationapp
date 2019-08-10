using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using LocationApp.Data.Dto;


namespace LocationApp.Service.Interfaces
{
    [ServiceContract(Namespace = "LocationApp.Service.Services.UserLoginService")]
    public interface IUserLoginService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddUserLogin")]
        string AddUserLogin(UserLoginDto userLoginDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SetUserLogin")]
        string SetUserLogin(UserLoginDto userLoginDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DelUserLogin?userLoginID={userLoginID}")]
        string DelUserLogin(int userLoginID);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUserLogin?userLoginID={userLoginID}")]
        string GetUserLogin(int userLoginID);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetUserLogin?Email={Email}")]
        string SendMail(string Email);
    }
}
