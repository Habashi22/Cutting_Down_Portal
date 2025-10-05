using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{
    public class Channel
    {
        [Key]
        public int Channel_Key { get; set; }
        public string Channel_Name { get; set; } = string.Empty;
    }
}
