namespace backend.Core.DTOs.Candidate
{
    public class CandidateGetDTO
    {

        public long ID { get; set; } 
         
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeURL { get; set; }

        public long JobID { get; set; }

        public string JobTitle { get; set; }
    }
}
