namespace RecruitmentTool.Services
{
    using System.Collections.Generic;

    using RecruitmentTool.Models.Candidates;
    using RecruitmentTool.Models.Recruiters;
    using RecruitmentTool.Models.Skills;

    public interface ICandidatesService
    {
        void Create(
        CandidateServiceModel candidateInput,
        IEnumerable<SkillServiceModel> skillsInput,
        RecruiterDataModel recruiterInput);

        CandidateDataModel ById(int id);

        public void Update(
          int id,
          CandidateServiceModel candidateInput,
          IEnumerable<SkillServiceModel> skillsInput,
          RecruiterDataModel recruiterInput);

        void Delete(int id);
    }
}
