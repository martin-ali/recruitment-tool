namespace RecruitmentTool.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using RecruitmentTool.Data;
    using RecruitmentTool.Data.Models;
    using RecruitmentTool.Models.Candidates;
    using RecruitmentTool.Models.Recruiters;
    using RecruitmentTool.Models.Skills;

    public class CandidatesService : ICandidatesService
    {
        private readonly RecruitmentDbContext data;
        private readonly ISkillsService skills;
        private readonly ICandidateSkillsService candidateSkills;
        private readonly IRecruitersService recruiters;
        private readonly IMapper mapper;

        public CandidatesService(
            RecruitmentDbContext data,
            ISkillsService skills,
            ICandidateSkillsService candidateSkills,
            IRecruitersService recruiters,
            IMapper mapper)
        {
            this.data = data;
            this.skills = skills;
            this.candidateSkills = candidateSkills;
            this.recruiters = recruiters;
            this.mapper = mapper;
        }

        public void Create(
            CandidateServiceModel candidateInput,
            IEnumerable<SkillServiceModel> skillsInput,
            RecruiterDataModel recruiterInput)
        {
            var skills = this.skills.EnsureAll(skillsInput);
            var candidateSkills = this.candidateSkills.EnsureAll(skills);

            var recruiter = this.recruiters.Ensure(recruiterInput);
            recruiter.ExperienceLevel++;

            var candidate = this.mapper.Map<Candidate>(candidateInput);
            candidate.Recruiter = recruiter;
            candidate.CandidateSkills = candidateSkills;

            this.data.Candidates.Add(candidate);

            this.data.SaveChanges();
        }

        public CandidateDataModel ById(int id)
        {
            var candidate = this.data.Candidates
                .Where(c => c.Id == id)
                .ProjectTo<CandidateDataModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            return candidate;
        }

        public void Update(
            int id,
            CandidateServiceModel candidateInput,
            IEnumerable<SkillServiceModel> skillsInput,
            RecruiterDataModel recruiterInput)
        {
            var skills = this.skills.EnsureAll(skillsInput);
            var candidateSkills = this.candidateSkills.EnsureAll(skills);

            var recruiter = this.recruiters.Ensure(recruiterInput);

            var candidate = this.data.Candidates.Find(id);
            candidate.FirstName = candidateInput.FirstName;
            candidate.LastName = candidateInput.LastName;
            candidate.Email = candidateInput.Email;
            candidate.Bio = candidateInput.Bio;
            candidate.BirthDate = candidateInput.BirthDate;
            candidate.Recruiter = recruiter;
            candidate.CandidateSkills = candidateSkills;

            this.data.SaveChanges();
        }

        public void Delete(int id)
        {
            var candidate = this.data.Candidates.Find(id);

            this.data.Candidates.Remove(candidate);

            this.data.SaveChanges();
        }
    }
}
