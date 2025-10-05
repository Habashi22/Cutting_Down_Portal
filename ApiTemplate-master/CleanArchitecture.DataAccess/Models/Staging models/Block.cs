namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Block
    {
        public int Block_Key { get; set; }
        public int Cable_Key { get; set; }

        public string Block_Name { get; set; } = string.Empty;

        // Navigation
        public Cable? Cable { get; set; }
        public ICollection<Building>? Buildings { get; set; }
    }
}
