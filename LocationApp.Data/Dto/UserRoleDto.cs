using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LocationApp.Data.Dto
{   [DataContract]
    public class UserRoleDto
    {
        [DataMember]
        public int UserRoleID { get; set; }
        [DataMember]
        public string UserRoleName { get; set;}
        [DataMember]
        public string UserRoleDescription { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
