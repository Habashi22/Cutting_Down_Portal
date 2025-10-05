using CleanArchitecture.DataAccess.Models.Staging_models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{
    public class Network_Element
    {
        [Key]
        public int Network_Element_Key { get; set; }
        public string Network_Element_Name { get; set; } = string.Empty;

        public int Network_Element_Type_Key { get; set; }
        public virtual Network_Element_Type Network_Element_Type { get; set; } = null!;

        public int? Parent_Network_Element_Key { get; set; }
        public virtual Network_Element? Parent_Network_Element { get; set; }

        public virtual ICollection<Network_Element> Child_Elements { get; set; } = new List<Network_Element>();



        // Foreign Key (assuming each network element can be linked with multiple CuttingDownDetails)
        public ICollection<Cutting_Down_Detail> CuttingDownDetails { get; set; } = new List<Cutting_Down_Detail>();

        // Optionally, you can also add a navigation property for related CuttingDownA
        // If the relationship is one-to-many (one CuttingDownA to many Network Elements)
        public ICollection<CuttingDownA> CuttingDownAs { get; set; } = new List<CuttingDownA>();
        public ICollection<CuttingDownB> CuttingDownBs { get; set; } = new List<CuttingDownB>();

    }
}
