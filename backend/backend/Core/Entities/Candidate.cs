namespace backend.Core.Entities
{
    public class Candidate:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeURL { get; set; }

        public long JobID { get; set; }

        public Job job { get; set; }
    }
}
