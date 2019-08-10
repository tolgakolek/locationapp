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
    public class BlockDto
    {
        [DataMember]
        public int BlockID { get; set; }
        [DataMember]
        public int BuildID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gps { get; set; }
        [DataMember]
        public BuildDto BuildDto { get; set; }
    }
}
