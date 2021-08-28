namespace RecruitmentTool.Services
{
    using System.Collections.Generic;

    using RecruitmentTool.Data.Models;
    using RecruitmentTool.Models.Skills;

    public interface ISkillsService
    {
        IEnumerable<Skill> EnsureAll(IEnumerable<SkillServiceModel> skillsInput);

        IEnumerable<SkillServiceModel> AllWithCandidates();
    }
}
