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
    public class UserDto
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string NationID { get; set; }
        [DataMember]
        public int UserTitleID { get; set; }
        [DataMember]
        public UserTitleDto UserTitleDto { get; set; }
        [DataMember]
        public int UserContactID { get; set; }
        [DataMember]
        public UserContactDto UserContactDto { get; set; }
        [DataMember]
        public int UserPasswordID { get; set; }
        [DataMember]
        public UserPasswordDto UserPasswordDto { get; set; }
        [DataMember]
        public int UserDepartmentID { get; set; }
        [DataMember]
        public UserDepartmentDto UserDepartmentDto { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public DepartmentDto DepartmentDto { get; set; }
        [DataMember]
        public int UserRoleID { get; set; }
        [DataMember]
        public UserRoleDto UserRoleDto { get; set; }
    }
}
