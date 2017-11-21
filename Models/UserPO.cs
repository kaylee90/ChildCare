using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChildCare.Models
{
    public class UserPO
    {
       
        public Int64 UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Username cannot be longer than 25 characters.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Password cannot be longer than 15 characters.")]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()+=]).{4,15}", ErrorMessage = "Password did not meet the required fields")]
        public string Password { get; set; }

        public Int64 RoleID { get; set; }
    }
}