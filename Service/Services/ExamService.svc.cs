using Examp.Dto;
using Newtonsoft.Json;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExamService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ExamService.svc or ExamService.svc.cs at the Solution Explorer and start debugging.
    public class ExamService : IExamService
    {
        private Core.Logic.ExamLogic examLogic = new Core.Logic.ExamLogic();
        public string AddExam(ExamDto examDto)
        {
            return JsonConvert.SerializeObject(examLogic.AddExam(examDto));
        }

        public string DeleteExam(int ExamID)
        {
            return JsonConvert.SerializeObject(examLogic.DelExam(ExamID));
        }

        public string GetAllExam()
        {
            return JsonConvert.SerializeObject(examLogic.GetAllExam(), Formatting.Indented);
        }

        public string GetExam(int ExamID)
        {
            return JsonConvert.SerializeObject(examLogic.GetExam(ExamID));

        }

        public string SetExam(ExamDto examDto)
        {
            return JsonConvert.SerializeObject(examLogic.SetExam(examDto));
        }
    }
}
