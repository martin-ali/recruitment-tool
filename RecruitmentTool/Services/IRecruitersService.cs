namespace RecruitmentTool.Services
{
    using RecruitmentTool.Data.Models;
    using RecruitmentTool.Models.Recruiters;

    public interface IRecruitersService
    {
        Recruiter Ensure(RecruiterDataModel input);
    }
}
