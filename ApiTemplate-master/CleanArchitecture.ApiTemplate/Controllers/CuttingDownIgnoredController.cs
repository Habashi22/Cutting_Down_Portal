using CleanArchitecture.DataAccess.Models.Fact_models;
using CleanArchitecture.Services.DTOs.CuttingDownIgnoredAddDto;
using CleanArchitecture.Services.Interfaces;
using CleanArchitecture.Services.Interfaces.ICuttingDownIgnoredService;
using CleanArchitecture.Services.Services.CuttingDownIgnoredService;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuttingDownIgnoredController : ControllerBase
    {
        private readonly ICuttingDownIgnoredService _ignoredService;

        public CuttingDownIgnoredController(ICuttingDownIgnoredService ignoredService)
        {
            _ignoredService = ignoredService;
        }

        // GET: api/ignored?pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _ignoredService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        // GET: api/ignored/search?cableName=abc&cabinName=xyz
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? query)
        {
            var result = await _ignoredService.SearchAsync( query);
            return Ok(result);
        }

        // POST: api/ignored
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CuttingDownIgnoredAddDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var added = await _ignoredService.AddAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = added.Cutting_Down_Incident_ID }, added);
        }

        // DELETE: api/ignored/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _ignoredService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }


        [HttpGet("export-excel")]
        public async Task<IActionResult> ExportToExcel()
        {
            var fileContent = await _ignoredService.ExportIgnoredToExcelAsync();

            return File(fileContent,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"IgnoredIncidents_{DateTime.UtcNow:yyyyMMddHHmmss}.xlsx");
        }



        //[HttpGet("export-pdf")]
        //public async Task<IActionResult> ExportToPdf()
        //{
        //    var fileContent = await _ignoredService.ExportIgnoredToPdfAsync();

        //    return File(fileContent, "application/pdf", "CuttingDownIgnored.pdf");
        //}

    }
}
