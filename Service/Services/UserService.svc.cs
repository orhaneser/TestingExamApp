using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Examp.Dto;
using Newtonsoft.Json;
using Service.Interfaces;

namespace Service.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private Core.Logic.UserLogic userLogic = new Core.Logic.UserLogic();

        public string AddUser(UserDto userDto)
        {
            return JsonConvert.SerializeObject(userLogic.AddUser(userDto));
        }

        public string DeleteUser(int UserID)
        {
            return JsonConvert.SerializeObject(userLogic.DelUser(UserID));
        }

        public string GetAllUser()
        {
            return JsonConvert.SerializeObject(userLogic.GetAllUser(), Formatting.Indented);
        }

        public string GetUser(int UserID)
        {
            return JsonConvert.SerializeObject(userLogic.GetUser(UserID));
        }

        public string SetUser(UserDto userDto)
        {
            return JsonConvert.SerializeObject(userLogic.SetUser(userDto));
        }
    }
}
