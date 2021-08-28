namespace RecruitmentTool.Models.Recruiters
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    public class RecruiterDataModel
    {
        [Required]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string Country { get; init; }
    }
}
