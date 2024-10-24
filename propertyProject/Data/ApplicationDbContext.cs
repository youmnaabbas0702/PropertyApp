namespace propertyProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyService>()
            .HasKey(ps => new { ps.PropertyId, ps.ServiceId });

            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City {CityId = 1, CityName = "Sadat"},
                new City {CityId = 2, CityName = "Shebin Elkom"},
                new City {CityId = 3, CityName = "Menouf"},
            });

            modelBuilder.Entity<Admin>().HasData(new Admin[]
            {
                new Admin {Id = 1, Email = "Admin11.EasyStay@gmail.com", Password = "admin11#*33", CityId = 1},
                new Admin {Id = 2, Email = "Admin22.EasyStay@gmail.com", Password = "admin22#*44", CityId = 2},
                new Admin {Id = 3, Email = "Admin33.EasyStay@gmail.com", Password = "admin33#*55", CityId = 3},
            });

            modelBuilder.Entity<Service>().HasData( new Service[] 
            {
               new Service { Id = 1, Name = "Wi-Fi", Icon = "bi-wifi" },
               new Service { Id = 2, Name = "Electricity", Icon = "bi-lightning" },
               new Service { Id = 3, Name = "Gas", Icon = "bi-droplet-half" },
               new Service { Id = 4, Name = "Elevator", Icon = "fa-solid fa-elevator" },
               new Service { Id = 5, Name = "Fans", Icon = "bi bi-fan"},
               new Service { Id = 6, Name = "TV", Icon = "bi bi-tv" },
               new Service { Id = 7, Name = "Water Filter",Icon = "fa-solid fa-faucet" },
               new Service { Id = 8, Name = "Cleaning Services", Icon = "fa-regular fa-washing-machine" },
               new Service { Id = 9, Name = "Security", Icon = "fa-solid fa-person-military-pointing" },
               new Service { Id = 10, Name = "Fire Safety", Icon = "fa fa-fire-extinguisher" },
               new Service { Id = 11, Name = "Garbage Disposal", Icon = "bi bi-trash" }
            }
            );

            modelBuilder.Entity<User>().Property(u => u.Gender).HasConversion<string>();
            modelBuilder.Entity<Property>().Property(p => p.Gender).HasConversion<string>();

            modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedNever();
            modelBuilder.Entity<Admin>()
            .Property(u => u.Id)
            .ValueGeneratedNever();
            modelBuilder.Entity<Property>()
            .Property(u => u.Id)
            .ValueGeneratedNever();
            modelBuilder.Entity<City>()
            .Property(u => u.CityId)
            .ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<PropertyService> PropertyServices { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
