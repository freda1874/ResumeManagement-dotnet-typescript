using backend.Core.Enums;

namespace backend.Core.DTOs.Company
{
    public class CompanyCreateDTO
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
