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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISubjectLessonService" in both code and config file together.
    [ServiceContract(Namespace = "LocationApp.Service.Services.SubjectLessonService")]
    public interface ISubjectLessonService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "AddSubjectLesson")]
        string AddSubjectLesson(SubjectLessonDto subjectLessonDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SetSubjectLesson")]
        string SetSubjectLesson(SubjectLessonDto subjectLessonDto);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "DeleteSubjectLesson?SubjectLessonID={SubjectLessonID}")]
        string DeleteSubjectLesson(int SubjectLessonID);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetSubjectLesson?SubjectLessonID={SubjectLessonID}")]
        string GetSubjectLesson(int SubjectLessonID);
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllSubjectLesson")]
        string GetAllSubjectLesson();
    }
}
