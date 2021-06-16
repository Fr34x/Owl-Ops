using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Owl_Ops_Webserver.Model
{
    public partial class OwlDatabaseContext : IdentityDbContext<User> 
    {
        public OwlDatabaseContext()
        {
        }

        public OwlDatabaseContext(DbContextOptions<OwlDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=OwlDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.Sensor_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.Sensor_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Measurements)
                    .HasForeignKey(d => d.Sensor_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sensors)
                    .HasForeignKey(d => d.User_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
