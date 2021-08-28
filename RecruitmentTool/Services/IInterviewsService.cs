namespace RecruitmentTool.Services
{
    using System.Collections.Generic;

    using RecruitmentTool.Models.Interviews;

    public interface IInterviewsService
    {
        IEnumerable<InterviewDataModel> All();
    }
}
