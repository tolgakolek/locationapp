using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class FloorDto
    {
        [DataMember]
        public int FloorID { get; set; }
        [DataMember]
        public int BlockID { get; set; }
        [DataMember]
        public int BuildID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Other { get; set; }
        [DataMember]
        public string Map { get; set; }
        [DataMember]
        public BuildDto BuildDto { get; set; }
        [DataMember]
        public BlockDto BlockDto { get; set; }
    }
}
