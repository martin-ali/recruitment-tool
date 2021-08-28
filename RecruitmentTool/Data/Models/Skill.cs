namespace RecruitmentTool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Skill : BaseModel
    {
        [Required]
        public string Name { get; init; }

        public IEnumerable<Candidate> Candidates { get; init; } = new List<Candidate>();
    }
}
