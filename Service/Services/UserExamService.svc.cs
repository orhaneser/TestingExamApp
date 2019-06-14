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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserExamService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserExamService.svc or UserExamService.svc.cs at the Solution Explorer and start debugging.
    public class UserExamService : IUserExamService
    {
        private Core.Logic.UserExamLogic userExamLogic = new Core.Logic.UserExamLogic();

        public string AddUserExam(UserExamDto userExamDto)
        {
            return JsonConvert.SerializeObject(userExamLogic.AddUserExam(userExamDto));
        }

        public string DeleteUserExam(int QuestionID)
        {
            return JsonConvert.SerializeObject(userExamLogic.DelUserExam(QuestionID));
        }

        public string GetAllUserExam()
        {
            return JsonConvert.SerializeObject(userExamLogic.GetAllUserExam(), Formatting.Indented);
        }

        public string GetUserExam(int UserExamID)
        {
            return JsonConvert.SerializeObject(userExamLogic.GetUserExam(UserExamID));
        }

        public string SetUserExam(UserExamDto userExamDto)
        {
            return JsonConvert.SerializeObject(userExamLogic.SetUserExam(userExamDto));
        }
    }
}
