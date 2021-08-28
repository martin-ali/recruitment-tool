namespace RecruitmentTool.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using RecruitmentTool.Data;
    using RecruitmentTool.Data.Models;

    public class CandidateSkillsService : ICandidateSkillsService
    {
        private readonly RecruitmentDbContext data;
        private readonly ISkillsService skills;

        public CandidateSkillsService(RecruitmentDbContext data, ISkillsService skills)
        {
            this.data = data;
            this.skills = skills;
        }

        public IEnumerable<CandidateSkill> EnsureAll(IEnumerable<Skill> skills)
        {
            var candidateSkills = new List<CandidateSkill>();
            foreach (var skill in skills)
            {
                var candidateSkill = new CandidateSkill { Skill = skill };

                candidateSkills.Add(candidateSkill);
            }

            this.data.SaveChanges();

            return candidateSkills;
        }
    }
}
