﻿using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Models {
    public class OurDbContext : DbContext
    {
        public OurDbContext(DbContextOptions<OurDbContext> options): base(options) {

        }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<GeneralPractioner> GeneralPractioner { get; set; }
        public DbSet<Consult> Consult { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
    }
}
