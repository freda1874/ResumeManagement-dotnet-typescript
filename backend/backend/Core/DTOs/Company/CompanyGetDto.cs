﻿using backend.Core.Enums;

namespace backend.Core.DTOs.Company
{
    public class CompanyGetDto
    {

        public long ID { get; set; }
        public string Name { get; set; }
        public CompanySize Size { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
    }
}
