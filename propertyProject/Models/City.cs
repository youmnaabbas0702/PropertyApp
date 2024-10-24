namespace propertyProject.Models
{
    [Table("City")]
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public ICollection<Property> Properties { get; set; } = new List<Property>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
