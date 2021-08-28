namespace RecruitmentTool.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel
    {
        [Required]
        public int Id { get; init; }
    }
}
