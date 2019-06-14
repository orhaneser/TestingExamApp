using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]
   public class LessonDto
    {
        [DataMember]
        public int LessonID { get; set; }
        [DataMember]
        public string LessonText { get; set; }
    }
}
