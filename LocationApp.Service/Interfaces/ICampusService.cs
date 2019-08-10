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
    [ServiceContract(Namespace = "LocationApp.Service.Services.CampusService")]
    public interface ICampusService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "AddCampus")]
        string AddCampus(CampusDto campusDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SetCampus")]
        string SetCampus(CampusDto campusDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DelCampus?campusID={campusID}")]
        string DelCampus(int campusID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetCampus?campusID={campusID}")]
        string GetCampus(int campusID);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllCampus")]
        string GetAllCampus();
    }
}
