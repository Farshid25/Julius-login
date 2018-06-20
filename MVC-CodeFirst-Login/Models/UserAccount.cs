using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models {
    public class UserAccount
    {
        [Key]         
        public int UserId { get; set; }

        [Required(ErrorMessage ="F")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "F")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "F")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "F")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "F")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
          
        [Compare("Password", ErrorMessage ="pass moet moatch")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "F")]
        public int UserTypeId { get; set; }
        //public UserType UserType { get; set; }
        public List<UserType> UserTypes { get; set; }
    }
}
