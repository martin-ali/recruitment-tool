namespace RecruitmentTool.Models.Jobs
{
    using System.Collections.Generic;

    using RecruitmentTool.Models.Skills;

    public class JobDataModel
    {
        public string Title { get; init; }

        public string Description { get; init; }

        public decimal Salary { get; init; }

        public IEnumerable<SkillServiceModel> Skills { get; init; } = new List<SkillServiceModel>();
    }
}
