using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]

    public class UserDto
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserSurname { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool Role { get; set; }
    }
}
