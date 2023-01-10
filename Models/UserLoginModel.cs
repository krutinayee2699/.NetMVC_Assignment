using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.NETMVC_KrutiNayee.Models
{
    public class UserLoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailId is Required")]
        public string emailId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}