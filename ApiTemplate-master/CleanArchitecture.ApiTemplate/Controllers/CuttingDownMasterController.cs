using CleanArchitecture.Services.DTOs.CuttingDownAddDto;
using CleanArchitecture.Services.DTOs.CuttingDownMasterSearchDto;
using CleanArchitecture.Services.Interfaces.IcuttingDownMasterService;
using DocumentFormat.OpenXml.Presentation;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuttingDownMasterController : ControllerBase
    {
        private readonly ICuttingDownMasterService _cuttingDownMasterService;

        public CuttingDownMasterController(ICuttingDownMasterService cuttingDownMasterService)
        {
            _cuttingDownMasterService = cuttingDownMasterService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchTickets([FromBody] CuttingDownSearchDto searchDto)
        {
            if (searchDto == null)
                return BadRequest("Search criteria must be provided.");

            var result = await _cuttingDownMasterService.SearchTicketsAsync(searchDto);
            return Ok(result);
        }



        [HttpPost("add-manual-ticket")]
        public async Task<IActionResult> AddManualTicketAsync([FromBody] AddCuttingDownDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Request body is null.");
            }

            await _cuttingDownMasterService.AddManualTicketAsync(dto);
            return Ok(new { message = "Ticket added successfully." });
        }






    
        [HttpPost("export")]
        public async Task<IActionResult> ExportSearchResultsToExcel([FromBody] CuttingDownSearchDto searchDto)
        {
            var result = await _cuttingDownMasterService.SearchTicketsAsync(searchDto);

            using var workbook = new ClosedXML.Excel.XLWorkbook();
            var worksheet = workbook.Worksheets.Add("SearchResults");

            // Add headers correctly in columns 1 to 8
            worksheet.Cell(1, 1).Value = "IncidentId";
            worksheet.Cell(1, 2).Value = "ChannelName";
            worksheet.Cell(1, 3).Value = "ProblemTypeName";
            worksheet.Cell(1, 4).Value = "CreatedAt";
            worksheet.Cell(1, 5).Value = "EndedAt";
            worksheet.Cell(1, 6).Value = "IsGlobal";
            worksheet.Cell(1, 7).Value = "IsPlanned";
            worksheet.Cell(1, 8).Value = "ImpactedCustomers";

            var row = 2;
            foreach (var item in result.Results)
            {
                worksheet.Cell(row, 1).Value = item.IncidentId;
                worksheet.Cell(row, 2).Value = item.ChannelName;
                worksheet.Cell(row, 3).Value = item.ProblemTypeName;
                worksheet.Cell(row, 4).Value = item.CreatedAt.ToString("yyyy-MM-dd HH:mm");
                worksheet.Cell(row, 5).Value = item.EndedAt?.ToString("yyyy-MM-dd HH:mm");
                worksheet.Cell(row, 6).Value = item.IsGlobal;
                worksheet.Cell(row, 7).Value = item.IsPlanned;
                worksheet.Cell(row, 8).Value = item.ImpactedCustomers;

                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "CuttingDownSearchResults.xlsx");
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CuttingDownResultDto>> GetTicketById(int id)
        {
            var result = await _cuttingDownMasterService.GetTicketByIdAsync(id);

            if (result == null)
                return NotFound($"Ticket with ID {id} not found.");

            return Ok(result);
        }



    }
}
