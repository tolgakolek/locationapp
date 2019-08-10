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
    public class RoomDto
    {
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public int FloorID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int RoomTypeID { get; set; }
        [DataMember]
        public string Map { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public DepartmentDto DepartmentDto { get; set; }
        [DataMember]
        public DepartmentRoomDto DepartmentRoomDto { get; set; }
        [DataMember]
        public BuildDto BuildDto { get; set; }
        [DataMember]
        public BlockDto BlockDto { get; set; }
        [DataMember]
        public FloorDto FloorDto { get; set; }
    }
}
