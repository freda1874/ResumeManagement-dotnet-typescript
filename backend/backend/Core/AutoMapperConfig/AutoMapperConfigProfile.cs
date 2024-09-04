using AutoMapper;
using backend.Core.DTOs.Candidate;
using backend.Core.DTOs.Company;
using backend.Core.DTOs.Job;
using backend.Core.Entities;

namespace backend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile:Profile
    {
        public AutoMapperConfigProfile()
        {
            //company
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<Company, CompanyGetDto>();
            //job
            CreateMap<JobCreateDTO, Job>();
            CreateMap<Job, JobGetDTO>()
                .ForMember(dest => dest.CompanyName,opt=>opt.MapFrom(src => src.Company.Name));

            //candidate
            CreateMap<CandidateCreateDTO, Candidate>();
            CreateMap<Candidate, CandidateGetDTO>()
              .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.job.Title));
        }
    }
}
