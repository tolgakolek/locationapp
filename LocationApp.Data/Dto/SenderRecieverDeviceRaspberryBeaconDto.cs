using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class SenderRecieverDeviceRaspberryBeaconDto
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string DeviceID { get; set; }
        [DataMember]
        public string CreationDate { get; set; }
        [DataMember]
        public string Counter { get; set; }
        [DataMember]
        public string Device_Name_1 { get; set; }
        [DataMember]
        public string Device_Name_2 { get; set; }
        [DataMember]
        public string Device_Name_3 { get; set; }
        [DataMember]
        public string Device_Name_4 { get; set; }
        [DataMember]
        public string Device_Name_5 { get; set; }
        [DataMember]
        public string Device_Name_6 { get; set; }
        [DataMember]
        public string Device_RSS_1 { get; set; }
        [DataMember]
        public string Device_RSS_2 { get; set; }
        [DataMember]
        public string Device_RSS_3 { get; set; }
        [DataMember]
        public string Device_RSS_4 { get; set; }
        [DataMember]
        public string Device_RSS_5 { get; set; }
        [DataMember]
        public string Device_RSS_6 { get; set; }
        [DataMember]
        public string Device_Distance_1 { get; set; }
        [DataMember]
        public string Device_Distance_2 { get; set; }
        [DataMember]
        public string Device_Distance_3 { get; set; }
        [DataMember]
        public string Device_Distance_4 { get; set; }
        [DataMember]
        public string Device_Distance_5 { get; set; }
        [DataMember]
        public string Device_Distance_6 { get; set; }
        [DataMember]
        public string Point_Location { get; set; }
    }
}
