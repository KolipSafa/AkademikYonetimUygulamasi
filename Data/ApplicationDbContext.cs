using AkademikProgramYonetimi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AkademikProgramYonetimi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ders> Dersler { get; set; } = null!;
        public DbSet<Derslik> Derslikler { get; set; } = null!;
        public DbSet<DersProgrami> DersProgramlari { get; set; } = null!;
        public DbSet<OgretimElemani> OgretimElemanlari { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri tanımla
            modelBuilder.Entity<DersProgrami>()
                .HasOne(d => d.Ders)
                .WithMany(c => c.DersProgramlari)
                .HasForeignKey(d => d.DersId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DersProgrami>()
                .HasOne(d => d.Derslik)
                .WithMany(c => c.DersProgramlari)
                .HasForeignKey(d => d.DerslikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DersProgrami>()
                .HasOne(d => d.OgretimElemani)
                .WithMany(c => c.DersProgramlari)
                .HasForeignKey(d => d.OgretimElemaniId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 