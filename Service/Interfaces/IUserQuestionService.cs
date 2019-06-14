using Examp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserQuestionService" in both code and config file together.
    [ServiceContract(Namespace = "LocationApp.Service.Services.UserQuestionService")]
    public interface IUserQuestionService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "AddUserQuestion")]
        string AddUserQuestion(UserQuestionDto userQuestionDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SetUserQuestion")]
        string SetUserQuestion(UserQuestionDto userQuestionDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DeleteUserQuestion?UserQuestionID={UserQuestionID}")]
        string DeleteUserQuestion(int UserQuestionID);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUserQuestion?UserQuestionID={UserQuestionID}")]
        string GetUserQuestion(int UserQuestionID);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllUserQuestion")]
        string GetAllUserQuestion();
    }
}
