namespace RecruitmentTool.Models.Interviews
{
    using RecruitmentTool.Models.Candidates;
    using RecruitmentTool.Models.Jobs;
    using RecruitmentTool.Models.Recruiters;

    public class InterviewDataModel
    {
        public CandidateDataModel Candidate { get; init; }

        public RecruiterDataModel Recruiter { get; init; }

        public JobDataModel Job { get; init; }
    }
}
