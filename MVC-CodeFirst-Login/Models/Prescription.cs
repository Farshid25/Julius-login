using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        public int Quantity { get; set; }
    }
}
