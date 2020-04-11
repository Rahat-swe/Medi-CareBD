
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using madicare.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

using madicare.Controllers;

namespace madicare.Data
{
    public class medicareDBContext:DbContext
    {
        public medicareDBContext(DbContextOptions<medicareDBContext> options)
            : base(options)
        {
        }

       public DbSet<Admin> admin { get; set; }
        public DbSet<AdminMediCare> admin_medi_care { get; set; }

        public DbSet<Doctor> doctors { get; set; }

        public DbSet<Patient> patient { get; set; }

        public DbSet<madicare.Models.VillageDetails> VillageDetails { get; set; }

        public DbSet<test> tests { get; set; }
        public DbSet<medicine> medicines { get; set; }

        
    }
}
