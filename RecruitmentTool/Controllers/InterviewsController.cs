namespace RecruitmentTool.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RecruitmentTool.Services;

    using static RecruitmentTool.Common.WebConstants.Routes;

    public class InterviewsController : ControllerBase
    {
        private const string Route = "/" + Interviews;
        private readonly IInterviewsService interviews;

        public InterviewsController(IInterviewsService interviews)
        {
            this.interviews = interviews;
        }


        [HttpGet(Route)]
        public IActionResult All()
        {
            var interviews = this.interviews.All();

            return this.Ok(interviews);
        }
    }
}
