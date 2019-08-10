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
    [ServiceContract(Namespace = "LocationApp.Service.Services.CampusSiteService")]
    public interface ICampusSiteService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "AddCampusSite")]
        string AddCampusSite(CampusSiteDto campusSiteDto);

        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SetCampusSite")]
        string SetCampusSite(CampusSiteDto campusSiteDto);

        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetCampusSite?campusSiteID={campusSiteID}")]
        string GetCampusSite(int campusSiteID);

        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DelCampusSite?campusSiteID={campusSiteID}")]
        string DelCampusSite(int campusSiteID);
    }
}
