namespace RecruitmentTool.Services
{
    using System.Collections.Generic;

    using RecruitmentTool.Data.Models;

    public interface ICandidateSkillsService
    {
        IEnumerable<CandidateSkill> EnsureAll(IEnumerable<Skill> skills);
    }
}
