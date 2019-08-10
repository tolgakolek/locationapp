using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class UserContactDto
    {
        [DataMember]
        public int UserContactID { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int UserContactTypeID { get; set; }
        [DataMember]
        public UserDto UserDto { get; set; }
        [DataMember]
        public UserContactTypeDto UserContactTypeDto { get; set; }
    }
}
