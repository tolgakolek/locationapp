using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace LocationApp.Data.Dto
{
    [DataContract]

    public class UserUserRoleDto
    {
        [DataMember]
        public int UserUserRoleID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int UserRoleID { get; set; }

    }
}
