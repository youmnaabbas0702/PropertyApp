namespace propertyProject.Models
{
    [Table("Admin")]
    public class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int CityId { get; set; }
        public City City { get; set; } = default!;
    }
}
