namespace propertyProject.Models
{
    public class PropertyService
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; } = default!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = default!;
    }
}
