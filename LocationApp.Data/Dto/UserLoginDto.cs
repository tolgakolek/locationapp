using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class UserLoginDto
    {
        [DataMember]
        public int UserLoginID { get; set;}
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime CreationDate { get; set; }
        [DataMember]
        public string IpAdress { get; set; }
        [DataMember]
        public int UserID { get; set; }
    }
}
