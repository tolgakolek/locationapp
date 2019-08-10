using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    public class DeviceDto
    {
        [DataMember]
        public int DeviceID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Properties { get; set; }
        [DataMember]
        public string Technology { get; set; }
        [DataMember]
        public int DeviceTypeID { get; set; }
        [DataMember]
        public DeviceTypeDto DeviceTypeDto { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public UserDto UserDto { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public RoomDto RoomDto { get; set; }
        [DataMember]
        public int DeviceRoomID { get; set; }
        [DataMember]
        public DeviceRoomDto DeviceRoomDto  { get; set; }
    }
}
