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
    public class SiteDto
    {
        public SiteDto()
        {
            CampusSiteDto = new CampusSiteDto();
        }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public int CampusID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Gps { get; set; }
        [DataMember]
        public int CampusSiteID { get; set; }
        [DataMember]
        public CampusSiteDto CampusSiteDto { get; set; }

    }
}
