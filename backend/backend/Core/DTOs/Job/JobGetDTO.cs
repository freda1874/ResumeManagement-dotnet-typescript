using backend.Core.Entities;
using backend.Core.Enums;

namespace backend.Core.DTOs.Job
{
    public class JobGetDTO
    {

        public long ID { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; } = true;

        public JobLevel Level { get; set; }

        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
         
    }
}
