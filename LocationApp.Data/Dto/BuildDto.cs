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
    public class BuildDto
    {
        [DataMember]
        public int BuildID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public int CampusID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Gps { get; set; }
        [DataMember]
        public string Properties { get; set; }
        [DataMember]
        public CampusDto CampusDto { get; set; }
        [DataMember]
        public SiteDto SiteDto { get; set; }

    }
}
