using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }

        public string Topic { get; set; }

        public DateTime BeginDate { get; set; }

        public int DSId { get; set; }

        public int HypotheseId { get; set; }

        public int ConsultId { get; set; }
    }
}
