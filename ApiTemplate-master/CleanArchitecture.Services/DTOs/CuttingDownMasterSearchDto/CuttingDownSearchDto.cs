using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.DTOs.CuttingDownMasterSearchDto
{
    public class CuttingDownSearchDto
    {
        public int? ChannelKey { get; set; }
        public int? ProblemTypeKey { get; set; }
        public int? GovernrateKey { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public bool? IsPlanned { get; set; }
        public bool? IsGlobal { get; set; }

        public bool? IsClosed { get; set; } // if true -> ActualEndDate != null

        // Network hierarchy
        public int? NetworkElementKey { get; set; }
        public int? NetworkElementTypeKey { get; set; }
        //--
        public HierarchyLevel? FilterLevel { get; set; }
        public int? FilterKey { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;


    }
    public enum HierarchyLevel
    {
        Governrate,
        Sector,
        Zone,
        City,
        Station,
        Tower,
        Cabin,
        Cable,
        Block,
        Building,
        Flat,
        Subscription
    }
}
