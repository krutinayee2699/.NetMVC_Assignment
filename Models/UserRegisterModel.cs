using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.NETMVC_KrutiNayee.Models
{
    public class UserRegisterModel
    {
        public int userId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name is Required")]
        [Display(Name ="First Name: ")]
        public string firstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name: ")]
        public string lastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailId is Required")]
        [Display(Name = "EmailId: ")]
        public string emailId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime createdOn { get; set; }
        public string SuccessMessage { get; set; }
    }
}