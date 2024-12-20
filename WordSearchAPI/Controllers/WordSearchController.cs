using Microsoft.AspNetCore.Mvc;
using WordSearchAPI.BusinessMethods;
using WordSearchAPI.Models;
using WordSearchAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WordSearchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordSearchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WordSearchController(AppDbContext context) { _context = context; }

        [HttpPost]
        [Route("contieneNombre")]
        public async Task<IActionResult> SearchName([FromBody] WordSearchRequest request)
        {
            if (request == null || request.WordSearchContent == null || string.IsNullOrEmpty(request.SearchedWord))
            {
                return BadRequest("Invalid request data.");
            }

            bool Result = new WordSearchManager().contieneNombre([.. request.WordSearchContent], request.SearchedWord);

            WordSearchLog Log = new()
            {
                WordSearchContent = string.Join(",", request.WordSearchContent),
                SearchedWord = request.SearchedWord,
                Result = Result
            };

            _context.WordSearchLogs.Add(Log);
            await _context.SaveChangesAsync();

            return Ok(new WordSearchResponse() { Result = Result });
        }

        [HttpGet]
        [Route("reporte")]
        public async Task<IActionResult> ObtenerReporte()
        {
            int TotalRecords = await _context.WordSearchLogs.CountAsync();
            int TotalFalseResults = await _context.WordSearchLogs.CountAsync(log => !log.Result);

            SearchReportResponse Response = new()
            {
                TotalFoundedRecords = TotalRecords-TotalFalseResults,
                TotalNotFoundedRecords = TotalFalseResults,
                ResultRatio = TotalRecords == 0 ? 0 : (TotalRecords - TotalFalseResults) / TotalRecords
            };

            return Ok(Response);
        }
    }
}