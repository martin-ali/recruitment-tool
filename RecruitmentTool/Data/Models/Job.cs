namespace RecruitmentTool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Job : BaseModel
    {
        [Required]
        public string Title { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        public decimal Salary { get; init; }

        public IEnumerable<Skill> Skills { get; init; } = new List<Skill>();

        public IEnumerable<Interview> Interviews { get; init; } = new List<Interview>();
    }
}
