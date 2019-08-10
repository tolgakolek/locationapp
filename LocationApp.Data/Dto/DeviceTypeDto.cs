using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace LocationApp.Data.Dto
{
    public class DeviceTypeDto
    {
        [DataMember]
        public int DeviceTypeID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
