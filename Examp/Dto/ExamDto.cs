using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]

  public class ExamDto
    {
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string Exam { get; set; }
    }
}
