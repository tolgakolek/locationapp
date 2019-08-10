using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class DepartmentRoomDto
    {
        [DataMember]
        public int DepartmentRoomID { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public string Other { get; set; }
    }
}
