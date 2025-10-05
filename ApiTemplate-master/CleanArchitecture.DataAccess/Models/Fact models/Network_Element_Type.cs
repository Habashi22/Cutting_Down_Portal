using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{
    public class Network_Element_Type
    {
        [Key]
        public int Network_Element_Type_key { get; set; } // Primary Key

        public string Network_Element_Type_Name { get; set; } = string.Empty; // Name of the Network Element Type

        public int? Parent_Network_Element_Type_Key { get; set; } // Foreign Key for the Parent (nullable)

        // Navigation Property to the Parent Network Element Type (Self-Referencing)
        public virtual Network_Element_Type? Parent_Network_Element_Type { get; set; }

        public int Network_Element_Hierarchy_Path_Key { get; set; } // Foreign Key to Hierarchy Path

        // Navigation Property to the Network Element Hierarchy Path
        public virtual Network_Element_Hierarchy_Path Network_Element_Hierarchy_Path { get; set; } = null!;

        // Collection of Child Network Element Types (Self-Referencing Relationship)
        public virtual ICollection<Network_Element_Type> Child_Types { get; set; } = new List<Network_Element_Type>();

        // Collection of Network Elements associated with this Network Element Type
        public virtual ICollection<Network_Element> Network_Elements { get; set; } = new List<Network_Element>();
    }
}
