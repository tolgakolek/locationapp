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
   public class UserTitleDto
    {
        [DataMember]
        public int UserTitleId { get; set; }
        [DataMember]
        public string TitleName { get; set; }
    }
}
