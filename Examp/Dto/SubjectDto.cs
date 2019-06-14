using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]
  public  class SubjectDto
    {
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectText { get; set; }
    }
}
