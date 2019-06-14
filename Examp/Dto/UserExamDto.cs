using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]

    public class UserExamDto
    {
        [DataMember]
        public int UserExamID { get; set; }
        [DataMember]
        public ExamDto examDto { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public UserDto userDto { get; set; }
        [DataMember]
        public int UserID { get; set; }
    }
}
