using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }

        public string TypeName { get; set; }
    }
}
