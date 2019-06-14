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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OptionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OptionService.svc or OptionService.svc.cs at the Solution Explorer and start debugging.
    public class OptionService : IOptionService
    {
        private Core.Logic.OptionLogic optionLogic = new Core.Logic.OptionLogic();

        public string AddOption(OptionDto optionDto)
        {
            return JsonConvert.SerializeObject(optionLogic.AddOption(optionDto));
        }

        public string DeleteOption(int OptionID)
        {
            return JsonConvert.SerializeObject(optionLogic.DelOption(OptionID));
        }

        public string GetAllOption()
        {
            return JsonConvert.SerializeObject(optionLogic.GetAllOption(), Formatting.Indented);
        }
        public string GetOption(int OptionID)
        {
            return JsonConvert.SerializeObject(optionLogic.GetOption(OptionID));
        }

        public string SetOption(OptionDto optionDto)
        {
            return JsonConvert.SerializeObject(optionLogic.SetOption(optionDto));
        }
    }
}
