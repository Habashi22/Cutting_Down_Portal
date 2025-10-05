using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{
    public class User
    {
        [Key]
        public int User_Key { get; set; }

        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
