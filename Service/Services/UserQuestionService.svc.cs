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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserQuestionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserQuestionService.svc or UserQuestionService.svc.cs at the Solution Explorer and start debugging.
    public class UserQuestionService : IUserQuestionService
    {
        private Core.Logic.UserQuestionLogic userQuestionLogic = new Core.Logic.UserQuestionLogic();

        public string AddUserQuestion(UserQuestionDto userQuestionDto)
        {
            return JsonConvert.SerializeObject(userQuestionLogic.AddUserQuestion(userQuestionDto));
        }

        public string DeleteUserQuestion(int UserQuestionID)
        {
            return JsonConvert.SerializeObject(userQuestionLogic.DelUserQuestion(UserQuestionID));
        }

        public string GetAllUserQuestion()
        {
            return JsonConvert.SerializeObject(userQuestionLogic.GetAllUserQuestion(), Formatting.Indented);
        }

        public string GetUserQuestion(int UserQuestionID)
        {
            return JsonConvert.SerializeObject(userQuestionLogic.GetUserQuestion(UserQuestionID));
        }

        public string SetUserQuestion(UserQuestionDto userQuestionDto)
        {
            return JsonConvert.SerializeObject(userQuestionLogic.SetUserQuestion(userQuestionDto));
        }
    }
}
