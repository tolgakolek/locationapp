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
    [ServiceContract(Namespace = "LocationApp.Service.Services.UserTitleService")]
    public interface IUserTitleService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddUserTitle")]
        string AddUserTitle(UserTitleDto userTitleDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SetUserTitle")]
        string SetUserTitle(UserTitleDto userTitleDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DelUserTitle?userTitleId={userTitleId}")]
        string DelUserTitle(int userTitleId);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "GetUserTitle?userTitleId={userTitleId}")]
        string GetUserTitle(int userTitleId);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAllUserTitle")]
        string GetAllUserTitle();
    }
}
