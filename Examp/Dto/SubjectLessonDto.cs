using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]
   public class SubjectLessonDto
    {
        [DataMember]
        public int SubjectLessonID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public SubjectDto subjectDto { get; set; }
        [DataMember]
        public int LessonID { get; set; }
        [DataMember]
        public LessonDto lessonDto { get; set; }
    }
}
