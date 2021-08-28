namespace RecruitmentTool.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using RecruitmentTool.Data;
    using RecruitmentTool.Models.Interviews;

    public class InterviewsService : IInterviewsService
    {
        private readonly RecruitmentDbContext data;
        private readonly IMapper mapper;

        public InterviewsService(RecruitmentDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IEnumerable<InterviewDataModel> All()
        {
            var interviews = this.data.Interviews
                .ProjectTo<InterviewDataModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return interviews;
        }
    }
}
