namespace RecruitmentTool.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using RecruitmentTool.Models.Candidates;
    using RecruitmentTool.Services;

    using static RecruitmentTool.Common.WebConstants.Routes;

    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private const string RouteBase = "/" + Candidates;
        private const string RouteId = "/" + Candidates + "/{id?}";

        private readonly ICandidatesService candidates;
        private readonly IMapper mapper;

        public CandidatesController(ICandidatesService candidates, IMapper mapper)
        {
            this.candidates = candidates;
            this.mapper = mapper;
        }

        [HttpPost(RouteBase)]
        public IActionResult Create(CandidateFormModel input)
        {
            var candidateInput = this.mapper.Map<CandidateServiceModel>(input);
            this.candidates.Create(candidateInput, input.Skills, input.Recruiter);

            return Ok();
        }

        [HttpGet(RouteId)]
        public IActionResult Details(int id)
        {
            var candidate = this.candidates.ById(id);

            return Ok(candidate);
        }

        [HttpPut(RouteId)]

        public IActionResult Update(int id, CandidateFormModel input)
        {
            var candidateInput = this.mapper.Map<CandidateServiceModel>(input);
            this.candidates.Update(id, candidateInput, input.Skills, input.Recruiter);

            return this.Ok();
        }

        [HttpDelete(RouteId)]

        public IActionResult Delete(int id)
        {
            this.candidates.Delete(id);

            return this.Ok();
        }
    }
}
