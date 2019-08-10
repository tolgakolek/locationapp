using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Data.Dto
{
    [DataContract]
    public class CampusSiteDto
    {
        [DataMember]
        public int CampusSiteID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public int CampusID { get; set; }
        [DataMember]
        public string Other { get; set; }
    }
}
