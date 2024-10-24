namespace propertyProject.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = default!;

    }
}
