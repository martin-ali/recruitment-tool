namespace RecruitmentTool.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using RecruitmentTool.Data;
    using RecruitmentTool.Data.Models;
    using RecruitmentTool.Models.Skills;

    public class SkillsService : ISkillsService
    {
        private readonly RecruitmentDbContext data;
        private readonly IMapper mapper;

        public SkillsService(RecruitmentDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IEnumerable<Skill> EnsureAll(IEnumerable<SkillServiceModel> skillsInput)
        {
            var skills = new List<Skill>();
            foreach (var skillInput in skillsInput)
            {
                var skill = this.data.Skills.FirstOrDefault(s => s.Name == skillInput.Name);

                if (skill == null)
                {
                    skill = new Skill { Name = skillInput.Name };
                    this.data.Skills.Add(skill);
                }

                skills.Add(skill);
            }

            this.data.SaveChanges();

            return skills;
        }

        public IEnumerable<SkillServiceModel> AllWithCandidates()
        {
            var skills = this.data.Skills
                .Where(s => s.CandidateSkills.Any())
                .ProjectTo<SkillServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return skills;
        }
    }
}
