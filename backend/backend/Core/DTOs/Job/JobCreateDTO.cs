using backend.Core.Enums;

namespace backend.Core.DTOs.Job
{
    public class JobCreateDTO
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }

        public long CompanyId { get; set; }

    }
}
