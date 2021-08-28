namespace RecruitmentTool.Models.Skills
{
    using System.ComponentModel.DataAnnotations;

    public class SkillServiceModel
    {
        [Required]
        public string Name { get; init; }
    }
}
