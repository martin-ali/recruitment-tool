namespace RecruitmentTool.Services
{
    using System.Collections.Generic;

    using RecruitmentTool.Models.Skills;

    public interface IJobsService
    {
        void Create(string title, string description, decimal salary, IEnumerable<SkillServiceModel> skillsInput);

        void Delete(int id);
    }
}
