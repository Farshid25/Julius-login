using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models
{
    public class Consult
    {
        [Key]
        public int ConsultId { get; set; }

        public int EpisodeId { get; set; }

        public DateTime BeginDate { get; set; }
    }
}
