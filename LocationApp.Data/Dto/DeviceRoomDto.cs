using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LocationApp.Data.Dto
{
    public class DeviceRoomDto
    {
        [DataMember]
        public int DeviceRoomID { get; set; }
        [DataMember]
        public string Location_X { get; set; }
        [DataMember]
        public string Location_Y { get; set; }
        [DataMember]
        public DateTime CreationDate { get; set; }
        [DataMember]
        public int DeviceID { get; set; }
        [DataMember]
        public DeviceDto DeviceDto { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public RoomDto RoomDto { get; set; }

    }
}
