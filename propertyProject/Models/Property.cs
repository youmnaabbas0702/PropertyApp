namespace propertyProject.Models
{
    [Table("Property")]
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public int RoomsAvailable { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public int CityId { get; set; }
        public City City { get; set; } = default!;
        public Gender Gender { get; set; }
        public ICollection<PropertyService> PropertyServices { get; set; } = new List<PropertyService>();

        // Property to hold the cover image URL/path
        public string CoverImage { get; set; } = string.Empty;

        // Navigation property to represent the relationship
        public List<Image> Images { get; set; } = new List<Image>();
    }
}
