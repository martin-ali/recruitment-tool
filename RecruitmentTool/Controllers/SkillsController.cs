namespace RecruitmentTool.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RecruitmentTool.Services;

    using static RecruitmentTool.Common.WebConstants.Routes;

    public class SkillsController : ControllerBase
    {
        private const string Route = "/" + Skills;

        private readonly ISkillsService skills;

        public SkillsController(ISkillsService skills)
        {
            this.skills = skills;
        }

        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Active()
        {
            var skills = this.skills.AllWithCandidates();

            return this.Ok(skills);
        }
    }
}
