namespace RecruitmentTool.Services
{
    using System.Linq;

    using RecruitmentTool.Data;
    using RecruitmentTool.Data.Models;
    using RecruitmentTool.Models.Recruiters;

    public class RecruitersService : IRecruitersService
    {
        private readonly RecruitmentDbContext data;

        public RecruitersService(RecruitmentDbContext data)
        {
            this.data = data;
        }

        public Recruiter Ensure(RecruiterDataModel input)
        {
            var recruiter = this.data.Recruiters
                .Where(r => r.LastName == input.LastName)
                .Where(r => r.Email == input.Email)
                .Where(r => r.Country == input.Country)
                .FirstOrDefault();

            if (recruiter == null)
            {
                recruiter = new Recruiter
                {
                    LastName = input.LastName,
                    Email = input.Email,
                    Country = input.Country,
                };

                this.data.Recruiters.Add(recruiter);
            }

            this.data.SaveChanges();

            return recruiter;
        }
    }
}
