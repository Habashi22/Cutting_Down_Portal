using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.DTOs.CuttingDownAddDto
{
    public class AddCuttingDownDto
    {
        // Required fields for Cutting_Down_Header
        public int ChannelKey { get; set; }
        public int ProblemTypeKey { get; set; }

        public DateTime ActualCreatedDate { get; set; } = DateTime.Now;
        public DateTime? ActualEndDate { get; set; }

        public bool IsPlanned { get; set; }
        public bool IsGlobal { get; set; }

        public DateTime? PlannedStartDTS { get; set; }
        public DateTime? PlannedEndDTS { get; set; }

        public int CreateSystemUserID { get; set; }
        public int UpdateSystemUserID { get; set; }

        // Cutting_Down_Detail
        public int? NetworkElementKey { get; set; } // Optional for now
        public int ImpactedCustomers { get; set; } = 0;

        // Optional: if you want to attach multiple details
        // public List<CuttingDownDetailDto> Details { get; set; }
    }

}
