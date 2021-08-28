namespace RecruitmentTool.Models.Candidates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using RecruitmentTool.Models.Recruiters;
    using RecruitmentTool.Models.Skills;

    public class CandidateFormModel
    {
        [Required]
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; init; }

        [Required]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string Bio { get; init; }

        [Required]
        [JsonProperty(PropertyName = "birth_date")]
        public DateTime BirthDate { get; init; }

        public RecruiterDataModel Recruiter { get; init; }

        public IEnumerable<SkillServiceModel> Skills { get; init; } = new List<SkillServiceModel>();
    }
}
