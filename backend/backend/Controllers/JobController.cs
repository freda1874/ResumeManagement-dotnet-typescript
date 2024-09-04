using AutoMapper;
using backend.Core.Context;
using backend.Core.DTOs.Company;
using backend.Core.DTOs.Job;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDTO dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();

            return Ok("Job created Successfully!");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDTO>>> GetCompanies()
        {
            var jobs = await _context.Jobs.Include(job => job.Company).OrderByDescending(q=>q.CreatedAt).ToListAsync();
            var convertedJobs = _mapper.Map<IEnumerable<JobGetDTO>>(jobs);

            return Ok(convertedJobs);
        }

    }
}
