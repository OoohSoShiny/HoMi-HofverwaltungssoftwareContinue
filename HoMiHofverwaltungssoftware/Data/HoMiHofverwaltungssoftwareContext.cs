using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Data
{
    public class HoMiHofverwaltungssoftwareContext : DbContext
    {
        public HoMiHofverwaltungssoftwareContext (DbContextOptions<HoMiHofverwaltungssoftwareContext> options)
            : base(options)
        {
        }

        public DbSet<HoMiHofverwaltungssoftware.Models.Cows> Cows { get; set; } = default!;
    }
}
