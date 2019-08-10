using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace LocationApp.Data.Dto
{
    [DataContract]
    public class UserPasswordDto
    {
        [DataMember]
        public int UserPasswordID { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int UserID { get; set; }
    }
}
