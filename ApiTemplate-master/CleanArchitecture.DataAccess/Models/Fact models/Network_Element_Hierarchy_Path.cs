using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{
    public class Network_Element_Hierarchy_Path
    {
        [Key]
        public int Network_Element_Hierarchy_Path_Key { get; set; }
        public string Netwrok_Element_Hierarchy_Path_Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;

        public virtual ICollection<Network_Element_Type> Network_Element_Types { get; set; } = new List<Network_Element_Type>();
    }
}
