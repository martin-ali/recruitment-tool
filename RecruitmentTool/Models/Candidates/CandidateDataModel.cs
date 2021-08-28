namespace RecruitmentTool.Models.Candidates
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using RecruitmentTool.Models.Recruiters;
    using RecruitmentTool.Models.Skills;

    public class CandidateDataModel
    {
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; init; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; init; }

        public string Email { get; init; }

        public string Bio { get; init; }

        [JsonProperty(PropertyName = "birth_date")]
        public DateTime BirthDate { get; init; }

        public RecruiterDataModel Recruiter { get; init; }

        public IEnumerable<SkillServiceModel> Skills { get; init; } = new List<SkillServiceModel>();
    }
}
