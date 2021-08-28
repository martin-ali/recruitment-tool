namespace RecruitmentTool.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Person : BaseModel
    {
        [Required]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
