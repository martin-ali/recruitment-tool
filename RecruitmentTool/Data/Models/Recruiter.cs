namespace RecruitmentTool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static RecruitmentTool.Common.DataConstants.Interviews;

    public class Recruiter : Person
    {
        [Required]
        public string Country { get; init; }

        [Required]
        public int InterviewSlotsFree = CountPerRecruiter;

        public IEnumerable<Interview> Interviews { get; init; } = new List<Interview>();

        public int ExperienceLevel { get; set; }
    }
}
