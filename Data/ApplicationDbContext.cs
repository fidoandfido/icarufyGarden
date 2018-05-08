using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IcarufyGarden.Models.Entities;
using IcarufyGarden.ViewModels;


namespace IcarufyGarden.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<GardenBed> GardenBeds { get; set; }
        public DbSet<GardenTask> GardenTask { get; set; }
        public DbSet<GardenBedsTasks> GardenBedTasks { get; set; }
        public DbSet<GardenBedOwners> GardenBedOwners { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Generate the identity model indexes!!!
            base.OnModelCreating(modelBuilder);

            // Now generate the garden bed tasks relationships
            modelBuilder.Entity<GardenBedsTasks>()
                .HasKey(x => new { x.TaskId, x.GardenBedId });

            modelBuilder.Entity<GardenBedsTasks>()
                .HasOne(x => x.GardenTask)
                .WithMany(y => y.GardenBedTasks)
                .HasForeignKey(x => x.TaskId);

            modelBuilder.Entity<GardenBedsTasks>()
                            .HasOne(x => x.GardenBed)
                            .WithMany(y => y.GardenBedTasks)
                            .HasForeignKey(x => x.GardenBedId);


            // Now generate the garden bed owner relationships
            modelBuilder.Entity<GardenBedOwners>()
                .HasKey(x => new { x.OwnerId, x.GardenBedId });

            modelBuilder.Entity<GardenBedOwners>()
                .HasOne(x => x.Owner)
                .WithMany(y => y.GardenBeds)
                .HasForeignKey(x => x.OwnerId);

            modelBuilder.Entity<GardenBedOwners>()
                            .HasOne(x => x.GardenBed)
                            .WithMany(y => y.Owners)
                            .HasForeignKey(x => x.GardenBedId);

            

        }

    }
}
