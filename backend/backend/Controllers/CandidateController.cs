using AutoMapper;
using backend.Core.Context;
using backend.Core.DTOs.Candidate;
using backend.Core.DTOs.Job;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {

        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDTO dto, IFormFile pdfFile)
        {
            var fiveMegaBytes = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if (pdfFile.Length > fiveMegaBytes || pdfFile.ContentType != pdfMimeType)
            {

                return BadRequest("File is not valid");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents", "pdfs", resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            var newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumeURL = resumeUrl;

            await _context.Candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();

            return Ok("Candidate Saved Successfully!");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDTO>>> GetCandidates()
        {
            var candidates = await _context.Candidates.Include(candidate => candidate.job).ToListAsync();
            var convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDTO>>(candidates);

            return Ok(convertedCandidates);
        }

        //read (download pdf file)

        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownLoadPdfFile(string url){
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents", "pdfs", url);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var pdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfBytes, "application/pdf", url);
            return file;
        }
    }
}
