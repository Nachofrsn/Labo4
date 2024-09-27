using concesionarioAPI.Models.Auto;
using concesionarioAPI.Models.Combustible;
using concesionarioAPI.Models.User;
using Microsoft.EntityFrameworkCore;

namespace concesionarioAPI.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Combustible> Combustibles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User {Id=1, Name = "Juan Perez", Email = "jp@mail.com", Username = "jperez", Password = "juanpi"}
                );
            modelBuilder.Entity<Auto>().HasData(
                new Auto
                {
                    Id = 1,
                    Marca = "Toyota",
                    Modelo = "Corolla",
                    CombustibleId = 1,
                    Transmision = "Automática",
                    TieneEstereo = true,
                    CantidadPuertas = 4,
                    FechaFabricacion = new DateTime(2020, 5, 14)
                },
                new Auto
                {
                    Id = 2,
                    Marca = "Honda",
                    Modelo = "Civic",
                    CombustibleId = 1,
                    Transmision = "Manual",
                    TieneEstereo = true,
                    CantidadPuertas = 4,
                    FechaFabricacion = new DateTime(2019, 7, 21)
                },
                new Auto
                {
                    Id = 3,
                    Marca = "Ford",
                    Modelo = "Focus",
                    CombustibleId = 2,
                    Transmision = "Automática",
                    TieneEstereo = false,
                    CantidadPuertas = 4,
                    FechaFabricacion = new DateTime(2021, 3, 10)
                },
                new Auto
                {
                    Id = 4,
                    Marca = "Chevrolet",
                    Modelo = "Cruze",
                    CombustibleId = 1,
                    Transmision = "Automática",
                    TieneEstereo = true,
                    CantidadPuertas = 4,
                    FechaFabricacion = new DateTime(2022, 11, 5)
                },
                new Auto
                {
                    Id = 5,
                    Marca = "Volkswagen",
                    Modelo = "Golf",
                    CombustibleId = 1,
                    Transmision = "Manual",
                    TieneEstereo = false,
                    CantidadPuertas = 4,
                    FechaFabricacion = new DateTime(2018, 2, 28)
                }
            );

            modelBuilder.Entity<Combustible>().HasData(
                new Combustible { Id = 1, Nombre = "Gasolina" },
                new Combustible { Id = 2, Nombre = "Diesel" },
                new Combustible { Id = 3, Nombre = "Gas" },
                new Combustible { Id = 4, Nombre = "Electricidad" }
            );
        }
    }
}
