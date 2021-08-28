namespace RecruitmentTool.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static RecruitmentTool.Common.DataConstants.Interviews;

    public class Recruiter : Person
    {
        [Required]
        public string Country { get; init; }

        [Required]
        public Interview[] Interviews { get; init; } = new Interview[CountPerRecruiter];

        [Required]
        public int ExperienceLevel { get; set; }
    }
}
