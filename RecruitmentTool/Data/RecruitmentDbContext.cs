namespace RecruitmentTool.Data
{
    using Microsoft.EntityFrameworkCore;

    using RecruitmentTool.Data.Models;

    using static RecruitmentTool.Common.DataConstants.Jobs;

    public class RecruitmentDbContext : DbContext
    {
        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options)
        : base(options) { }

        public DbSet<Skill> Skills { get; init; }
        public DbSet<Candidate> Candidates { get; init; }
        public DbSet<CandidateSkill> CandidateSkills { get; init; }
        public DbSet<Interview> Interviews { get; init; }
        public DbSet<Recruiter> Recruiters { get; init; }
        public DbSet<Job> Jobs { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Job>()
            .Property(j => j.Salary)
            .HasPrecision(SalaryPrecision, SalaryScale);

            builder.Entity<Interview>()
            .HasOne(i => i.Recruiter)
            .WithMany(r => r.Interviews)
            .HasForeignKey(i => i.RecruiterId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Recruiter>()
            .HasMany(r => r.Interviews)
            .WithOne(i => i.Recruiter)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
