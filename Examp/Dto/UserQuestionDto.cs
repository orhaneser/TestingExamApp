using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]

    public class UserQuestionDto
    {
        [DataMember]
        public int UserQuestionID { get; set; }
        [DataMember]
        public UserDto userDto { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int QuestionID { get; set; }
        [DataMember]
        public QuestionDto questionDto { get; set; }
        [DataMember]
        public int OptionID { get; set; }
        [DataMember]
        public OptionDto optionDto { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public SubjectDto subjectDto { get; set; }
    }
}
