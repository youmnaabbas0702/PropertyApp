namespace propertyProject.Models
{
    [Table("Image")]
    public class Image
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;

        // Foreign key to the Property table
        public int PropertyId { get; set; }

        // Navigation property back to the Property
        public Property Property { get; set; } = default!;
    }
}
