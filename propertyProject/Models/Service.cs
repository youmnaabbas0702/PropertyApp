namespace propertyProject.Models
{
    [Table("Service")]
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public ICollection<PropertyService> PropertyServices { get; set; } = new List<PropertyService>();
    }
}
