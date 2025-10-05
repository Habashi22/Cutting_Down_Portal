using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class ProblemType
    {
        [Key]
        public int Problem_Type_Key { get; set; }
        public string Problem_Type_Name { get; set; } = string.Empty;

        // Navigation
        public ICollection<CuttingDownA>? CuttingDownAs { get; set; }
        public ICollection<CuttingDownB>? CuttingDownBs { get; set; }
    }
}
