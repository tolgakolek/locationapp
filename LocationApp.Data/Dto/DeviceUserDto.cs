using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LocationApp.Data.Dto
{
    public class DeviceUserDto
    {
        [DataMember]
        public int DeviceUserID { get; set; }
        [DataMember]
        public int DeviceID { get; set; }
        [DataMember]
        public DeviceDto DeviceDto { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public UserDto UserDto { get; set; }
    }
}
