namespace RecruitmentTool.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Candidate : Person
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public IEnumerable<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();

        public int RecruiterId { get; set; }

        public Recruiter Recruiter { get; set; }
    }
}
