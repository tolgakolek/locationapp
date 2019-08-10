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
    public interface IMainUnitService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "AddMainUnit")]
        string AddMainUnit(MainUnitDto mainUnitDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SetMainUnit")]
        string SetMainUnit(MainUnitDto mainUnitDto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DelMainUnit?mainUnitId={mainUnitId}")]
        string DelMainUnit(int mainUnitId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetMainUnit?mainUnitId={mainUnitId}")]
        string GetMainUnit(int mainUnitId);
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetAllMainUnit")]
        string GetAllMainUnit();
    }
}
