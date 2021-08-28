namespace RecruitmentTool.Infrastructure
{
    using AutoMapper;

    using RecruitmentTool.Data.Models;
    using RecruitmentTool.Models.Candidates;
    using RecruitmentTool.Models.Interviews;
    using RecruitmentTool.Models.Jobs;
    using RecruitmentTool.Models.Recruiters;
    using RecruitmentTool.Models.Skills;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CandidateSkill, SkillServiceModel>()
            .ForMember(dm => dm.Name, cfg => cfg.MapFrom(m => m.Skill.Name));

            this.CreateMap<CandidateFormModel, CandidateServiceModel>();
            this.CreateMap<CandidateServiceModel, Candidate>();
            this.CreateMap<Candidate, CandidateDataModel>()
            .ForMember(dm => dm.Skills, cfg => cfg.MapFrom(m => m.CandidateSkills));

            this.CreateMap<Recruiter, RecruiterDataModel>()
            .ReverseMap();

            this.CreateMap<Skill, SkillServiceModel>();

            this.CreateMap<Job, JobDataModel>();

            this.CreateMap<Interview, InterviewDataModel>();
        }
    }
}
