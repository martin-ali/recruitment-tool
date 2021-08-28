namespace RecruitmentTool.Models.Candidates
{
    using System;

    public class CandidateServiceModel
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string Bio { get; init; }

        public DateTime BirthDate { get; init; }
    }
}
