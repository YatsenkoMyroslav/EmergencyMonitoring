using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EmergencyContext:DbContext
    {
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<EmergencyType> EmergencyTypes { get; set; }

        public EmergencyContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
