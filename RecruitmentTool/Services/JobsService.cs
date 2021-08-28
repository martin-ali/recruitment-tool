namespace RecruitmentTool.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using RecruitmentTool.Data;
    using RecruitmentTool.Data.Models;
    using RecruitmentTool.Models.Skills;

    public class JobsService : IJobsService
    {
        private readonly RecruitmentDbContext data;
        private readonly ISkillsService skills;

        public JobsService(RecruitmentDbContext data, ISkillsService skills)
        {
            this.data = data;
            this.skills = skills;
        }

        public void Create(string title, string description, decimal salary, IEnumerable<SkillServiceModel> skillsInput)
        {
            var skills = this.skills.EnsureAll(skillsInput);
            var job = new Job
            {
                Title = title,
                Description = description,
                Salary = salary,
                Skills = skills,
            };

            var suitableCandidates = this.data.Candidates
                .Where(c => c.CandidateSkills.Any(cs => skills.Contains(cs.Skill)))
                .Where(c => c.Recruiter.InterviewSlotsFree > 0);

            var interviews = new List<Interview>();
            foreach (var candidate in suitableCandidates)
            {
                var recruiter = candidate.Recruiter;

                if (recruiter.InterviewSlotsFree == 0)
                {
                    continue;
                }

                recruiter.ExperienceLevel++;
                recruiter.InterviewSlotsFree--;

                var interview = new Interview
                {
                    Recruiter = recruiter,
                    Candidate = candidate,
                    Job = job,
                };

                interviews.Add(interview);
            }

            job.Interviews = interviews;
            this.data.Jobs.Add(job);

            this.data.SaveChanges();
        }

        public void Delete(int id)
        {
            var job = this.data.Jobs.Find(id);
            var interviews = this.data.Interviews
                .Where(i => i.JobId == job.Id);

            foreach (var interview in interviews)
            {
                var recruiter = interview.Recruiter;

                this.data.Interviews.Remove(interview);

                recruiter.InterviewSlotsFree++;
            }

            this.data.SaveChanges();
        }
    }
}
