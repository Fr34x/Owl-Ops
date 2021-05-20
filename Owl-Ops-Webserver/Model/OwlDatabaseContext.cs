using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Owl_Ops_Webserver.Model
{
    public partial class OwlDatabaseContext : DbContext
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
