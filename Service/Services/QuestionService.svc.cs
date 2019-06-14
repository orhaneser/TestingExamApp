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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "QuestionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select QuestionService.svc or QuestionService.svc.cs at the Solution Explorer and start debugging.
    public class QuestionService : IQuestionService
    {
        private Core.Logic.QuestionLogic questionLogic = new Core.Logic.QuestionLogic();

        public string AddQuestion(QuestionDto questionDto)
        {
            return JsonConvert.SerializeObject(questionLogic.AddQuestion(questionDto));
        }

        public string DeleteQuestion(int QuestionID)
        {
            return JsonConvert.SerializeObject(questionLogic.DelQuestion(QuestionID));
        }

        public string GetAllQuestion()
        {
            return JsonConvert.SerializeObject(questionLogic.GetAllQuestion(), Formatting.Indented);
        }

        public string GetQuestion(int QuestionID)
        {
            return JsonConvert.SerializeObject(questionLogic.GetQuestion(QuestionID));
        }

        public string SetQuestion(QuestionDto questionDto)
        {
            return JsonConvert.SerializeObject(questionLogic.SetQuestion(questionDto));
        }
    }
}
