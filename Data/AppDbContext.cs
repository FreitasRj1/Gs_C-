using Microsoft.EntityFrameworkCore;
using WorkFutures.Api.Models;

namespace WorkFutures.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<JobMatch> JobMatches { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Configuração para Candidate (GUID gerado no Oracle com SYS_GUID())
            modelBuilder.Entity<Candidate>(eb =>
            {
                eb.HasKey(e => e.Id);
                // Mapeia o Guid para RAW(16) no Oracle e define DEFAULT sys_guid()
                eb.Property(e => e.Id)
                  .HasColumnType("RAW(16)")
                  .HasDefaultValueSql("SYS_GUID()")
                  .ValueGeneratedOnAdd();

                eb.Property(e => e.Name).IsRequired();
                eb.Property(e => e.Email).IsRequired();
                eb.Property(e => e.Skills).IsRequired(false);
                eb.Property(e => e.CreatedAt).HasDefaultValueSql("SYSTIMESTAMP");
            });

            // --- Configurações básicas para outras entidades (ex.: Course, JobMatch)
            modelBuilder.Entity<Course>(eb =>
            {
                eb.HasKey(e => e.Id);
                eb.Property(e => e.Id)
                  .HasColumnType("RAW(16)")
                  .HasDefaultValueSql("SYS_GUID()")
                  .ValueGeneratedOnAdd();

                eb.Property(e => e.Title).IsRequired();
                eb.Property(e => e.Provider).IsRequired(false);
                eb.Property(e => e.Description).IsRequired(false);
                eb.Property(e => e.CreatedAt).HasDefaultValueSql("SYSTIMESTAMP");
            });

            modelBuilder.Entity<JobMatch>(eb =>
            {
                eb.HasKey(e => e.Id);
                eb.Property(e => e.Id)
                  .HasColumnType("RAW(16)")
                  .HasDefaultValueSql("SYS_GUID()")
                  .ValueGeneratedOnAdd();

                // Relacionamento com Candidate
                eb.HasOne(j => j.Candidate)
                  .WithMany()
                  .HasForeignKey(j => j.CandidateId)
                  .OnDelete(DeleteBehavior.Cascade);

                // MatchScore: ajusta precisão para evitar warning/truncation no Oracle
                eb.Property(j => j.MatchScore).HasPrecision(5, 4); // ex.: 0.0000 - 9.9999
                eb.Property(e => e.CreatedAt).HasDefaultValueSql("SYSTIMESTAMP");
            });
        }
    }
}
