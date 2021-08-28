namespace RecruitmentTool.Data.Models
{
    public class Interview : BaseModel
    {
        public int CandidateId { get; init; }

        public Candidate Candidate { get; init; }

        public int RecruiterId { get; init; }

        public Recruiter Recruiter { get; init; }

        public int JobId { get; init; }

        public Job Job { get; init; }
    }
}
