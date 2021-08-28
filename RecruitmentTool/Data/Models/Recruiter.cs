namespace RecruitmentTool.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Recruiter : Person
    {
        [Required]
        public string Country { get; init; }
    }
}
