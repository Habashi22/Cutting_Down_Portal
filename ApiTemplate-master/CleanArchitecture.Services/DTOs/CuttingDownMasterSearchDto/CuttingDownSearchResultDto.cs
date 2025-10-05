using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.DTOs.CuttingDownMasterSearchDto
{
    public class CuttingDownSearchResultDto
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public List<CuttingDownResultDto> Results { get; set; } = new();
    }
}
