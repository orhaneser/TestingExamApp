using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Examp.Dto;
using Newtonsoft.Json;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SubjectLessonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SubjectLessonService.svc or SubjectLessonService.svc.cs at the Solution Explorer and start debugging.
    public class SubjectLessonService : ISubjectLessonService
    {
        private Core.Logic.SubjectLessonLogic subjectLessonLogic = new Core.Logic.SubjectLessonLogic();

        public string AddSubjectLesson(SubjectLessonDto subjectLessonDto)
        {
            return JsonConvert.SerializeObject(subjectLessonLogic.AddSubjectLesson(subjectLessonDto));
        }

        public string DeleteSubjectLesson(int SubjectLessonID)
        {
            return JsonConvert.SerializeObject(subjectLessonLogic.DelSubjectLesson(SubjectLessonID));
        }

        public string GetAllSubjectLesson()
        {
            return JsonConvert.SerializeObject(subjectLessonLogic.GetAllSubjectLesson(), Formatting.Indented);
        }

        public string GetSubjectLesson(int SubjectLessonID)
        {
            return JsonConvert.SerializeObject(subjectLessonLogic.GetSubjectLesson(SubjectLessonID));
        }

        public string SetSubjectLesson(SubjectLessonDto subjectLessonDto)
        {
            return JsonConvert.SerializeObject(subjectLessonLogic.SetSubjectLesson(subjectLessonDto));
        }
    }
}
