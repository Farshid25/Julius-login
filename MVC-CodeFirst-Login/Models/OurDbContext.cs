using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models {
    public class OurDbContext : DbContext
    {
        public OurDbContext(DbContextOptions<OurDbContext> options): base(options) {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<GeneralPractioner> GeneralPractioners { get; set; }
    }
}
