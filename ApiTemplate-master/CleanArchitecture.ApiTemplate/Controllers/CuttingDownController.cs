using CleanArchitecture.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuttingDownController : ControllerBase
    {
        private readonly ICuttingDownService _cuttingDownService;

        public CuttingDownController(ICuttingDownService cuttingDownService)
        {
            _cuttingDownService = cuttingDownService;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferCuttingDownData()
        {
            try
            {
               var result= await _cuttingDownService.TransferCuttingDownDataAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}