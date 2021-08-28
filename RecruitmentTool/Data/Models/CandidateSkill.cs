namespace RecruitmentTool.Data.Models
{
    public class CandidateSkill : BaseModel
    {
        public int CandidateId { get; init; }

        public Candidate Candidate { get; init; }

        public int SkillId { get; init; }

        public Skill Skill { get; init; }
    }
}
