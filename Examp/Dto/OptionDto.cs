using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Examp.Dto
{
    [DataContract]
  public  class OptionDto
    {
        [DataMember]
        public int OptionID { get; set; }
        [DataMember]
        public string OptionA{ get; set; }
        [DataMember]
        public string OptionB { get; set; }
        [DataMember]
        public string OptionC { get; set; }
        [DataMember]
        public string OptionD { get; set; }
        [DataMember]
        public string OptionE { get; set; }

    }
}
