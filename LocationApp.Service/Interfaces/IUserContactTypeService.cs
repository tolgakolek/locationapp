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
    [ServiceContract(Namespace = "LocationApp.Service.Services.UserContactTypeService")]
    public interface IUserContactTypeService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddUserContactType")]
        string AddUserContactType(UserContactTypeDto userContactTypeDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SetUserContactType")]
        string SetUserContactType(UserContactTypeDto userContactTypeDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DelUserContactType?userContactTypeID={userContactTypeID}")]
        string DelUserContactType(int userContactTypeID);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUserContactType?userContactTypeID={userContactTypeID}")]
        string GetUserContactType(int userContactTypeID);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetAllUserContactType")]
        string GetAllUserContactType();

    }
}
