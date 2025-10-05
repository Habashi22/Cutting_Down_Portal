using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.DTOs.CuttingDownMasterSearchDto
{
    public class CuttingDownResultDto
    {
        public int CuttingDownKey { get; set; }
        public int IncidentId { get; set; }

        public string ChannelName { get; set; } = string.Empty;
        public string ProblemTypeName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public bool IsPlanned { get; set; }
        public bool IsGlobal { get; set; }

        // New fields for 360-degree network context
        public string? NetworkElementName { get; set; }
        public string? NetworkElementType { get; set; }

        public int ImpactedCustomers { get; set; }
    }

}
