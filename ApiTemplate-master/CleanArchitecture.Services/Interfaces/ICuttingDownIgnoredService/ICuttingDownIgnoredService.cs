using CleanArchitecture.DataAccess.Models.Fact_models;
using CleanArchitecture.Services.DTOs.CuttingDownIgnoredAddDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.Interfaces.ICuttingDownIgnoredService
{
    public interface ICuttingDownIgnoredService
    {
        Task<IEnumerable<Cutting_Down_Ignored>> GetAllAsync(int pageNumber, int pageSize);
        // Task<IEnumerable<Cutting_Down_Ignored>> SearchAsync(string? cableName, string? cabinName);
        Task<IEnumerable<Cutting_Down_Ignored>> SearchAsync(string query);

        Task<Cutting_Down_Ignored> AddAsync(CuttingDownIgnoredAddDto dto);
        Task<bool> DeleteAsync(int id);
        Task<byte[]> ExportIgnoredToExcelAsync();
        Task<byte[]> ExportIgnoredToPdfAsync();


    }
}
