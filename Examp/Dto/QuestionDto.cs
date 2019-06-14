using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]

    public class QuestionDto
    {
        [DataMember]
        public int QuestionID { get; set; }
        [DataMember]
        public string QuestionText { get; set; }
        [DataMember]
        public int OptionID { get; set; }
        [DataMember]
        public OptionDto optionDto { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Difficult { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public SubjectDto subjectDto { get; set; }
        [DataMember]
        public string SubText { get; set; }
        [DataMember]
        public string AnswerKey { get; set; }



    }
}
