using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class UserContactTypeDto
    {
        [DataMember]
        public int UserContactTypeID { get; set; }
        [DataMember]
        public string TypeName { get; set; }
        [DataMember]
        public string Description { get; set; }
    

    }
}
