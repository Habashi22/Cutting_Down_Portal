namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Cable
    {
        public int Cable_Key { get; set; }
        public int Cabin_Key { get; set; }

        public string Cable_Name { get; set; } = string.Empty;

        // Navigation
        public Cabin? Cabin { get; set; }
        public ICollection<Block>? Blocks { get; set; }

    }
}
