namespace RecruitmentTool.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Person : BaseModel
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
