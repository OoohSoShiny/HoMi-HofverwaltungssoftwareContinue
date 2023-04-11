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

        public DbSet<HoMiHofverwaltungssoftware.Models.AnimalModel> AnimalModel { get; set; } = default!;

        public DbSet<HoMiHofverwaltungssoftware.Models.MatingModel>? MatingModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.AnimalNotesModel>? AnimalNotesModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.PastureGroupConnectorModel>? PastureGroupConnectorModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.PastureGroupsModel>? PastureGroupsModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.PastureModel>? PastureModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.PastureTimes>? PastureTimes { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.PregnancyCheckupModel>? PregnancyCheckupModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.RutCheckModel>? RutCheckModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.StableModel>? StableModel { get; set; }

        public DbSet<HoMiHofverwaltungssoftware.Models.OrderGroupsModel>? OrderGroupsModel { get; set; }
    }
}
