using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class UserDepartmentDto
    {
        [DataMember]
        public int UserDepartmentID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
    }
}
