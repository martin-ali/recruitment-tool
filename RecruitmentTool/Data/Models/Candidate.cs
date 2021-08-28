namespace RecruitmentTool.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Candidate : Person
    {
        [Required]
        public string FirstName { get; init; }

        [Required]
        public string Bio { get; init; }

        [Required]
        public DateTime BirthDate { get; init; }

        public IEnumerable<string> Skills { get; init; }

        public int RecruiterId { get; init; }

        public Recruiter Recruiter { get; init; }
    }
}