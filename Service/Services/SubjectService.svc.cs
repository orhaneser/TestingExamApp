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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SubjectService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SubjectService.svc or SubjectService.svc.cs at the Solution Explorer and start debugging.
    public class SubjectService : ISubjectService
    {
        private Core.Logic.SubjectLogic subjectLogic = new Core.Logic.SubjectLogic();

        public string AddSubject(SubjectDto subjectDto)
        {
            return JsonConvert.SerializeObject(subjectLogic.AddSubject(subjectDto));
        }

        public string DeleteSubject(int SubjectID)
        {
            return JsonConvert.SerializeObject(subjectLogic.DelSubject(SubjectID));
        }

        public string GetAllSubject()
        {
            return JsonConvert.SerializeObject(subjectLogic.GetAllSubject(), Formatting.Indented);
        }

        public string GetSubject(int SubjectID)
        {
            return JsonConvert.SerializeObject(subjectLogic.GetSubject(SubjectID));
        }

        public string SetSubject(SubjectDto subjectDto)
        {
            return JsonConvert.SerializeObject(subjectLogic.SetSubject(subjectDto));
        }
    }
}
