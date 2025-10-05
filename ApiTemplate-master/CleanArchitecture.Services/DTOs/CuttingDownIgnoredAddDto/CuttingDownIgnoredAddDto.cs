using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Services.DTOs.CuttingDownIgnoredAddDto
{
    public class CuttingDownIgnoredAddDto
    {
        [Required]
        public DateTime ActualCreatetDate { get; set; }

        [Required]
        public DateTime SynchCreateDate { get; set; }

        public string? Cabel_Name { get; set; }

        public string? Cabin_Name { get; set; }

        public string? CreatedUser { get; set; }
    }
}
