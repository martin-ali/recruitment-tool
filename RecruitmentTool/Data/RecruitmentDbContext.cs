namespace RecruitmentTool.Data
{
    using Microsoft.EntityFrameworkCore;
    using RecruitmentTool.Data.Models;

    public class RecruitmentDbContext : DbContext
    {
        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options)
        : base(options) { }

        public DbSet<Recruiter> Recruiters { get; init; }
        public DbSet<Candidate> Candidates { get; init; }
        public DbSet<Skill> Skills { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
