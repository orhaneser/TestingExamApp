using Examp.Dto;
using Newtonsoft.Json;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LessonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LessonService.svc or LessonService.svc.cs at the Solution Explorer and start debugging.
    public class LessonService : ILessonService
    {
        private Core.Logic.LessonLogic lessonLogic = new Core.Logic.LessonLogic();

        public string AddLesson(LessonDto lessonDto)
        {
            return JsonConvert.SerializeObject(lessonLogic.AddLesson(lessonDto));
        }

        public string DeleteLesson(int LessonID)
        {
            return JsonConvert.SerializeObject(lessonLogic.DelLesson(LessonID));
        }

        public string GetAllLesson()
        {
            return JsonConvert.SerializeObject(lessonLogic.GetAllLesson(), Formatting.Indented);
        }

        public string GetLesson(int LessonID)
        {
            return JsonConvert.SerializeObject(lessonLogic.GetLesson(LessonID));
        }

        public string SetLesson(LessonDto lessonDto)
        {
            return JsonConvert.SerializeObject(lessonLogic.SetLesson(lessonDto));
        }
    }
}
