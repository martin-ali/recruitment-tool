namespace RecruitmentTool.Models.Jobs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RecruitmentTool.Models.Skills;

    public class JobCreateModel
    {
        [Required]
        public string Title { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        public decimal Salary { get; init; }

        public IEnumerable<SkillServiceModel> Skills { get; init; } = new List<SkillServiceModel>();
    }
}
