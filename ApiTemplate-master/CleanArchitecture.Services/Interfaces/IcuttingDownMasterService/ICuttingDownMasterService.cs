using CleanArchitecture.Services.DTOs.CuttingDownAddDto;
using CleanArchitecture.Services.DTOs.CuttingDownMasterSearchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.Interfaces.IcuttingDownMasterService
{
   
        public interface ICuttingDownMasterService
        {
            Task<CuttingDownSearchResultDto> SearchTicketsAsync(CuttingDownSearchDto dto);
            Task AddManualTicketAsync(AddCuttingDownDto dto);
        Task<CuttingDownResultDto> GetTicketByIdAsync(int id);  // new method

    }
}

