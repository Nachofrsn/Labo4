using concesionarioAPI.Config;
using concesionarioAPI.Models.Combustible;

namespace concesionarioAPI.Repositories
{
    public interface ICombustibleRepository : IRepository<Combustible> { }
    public class CombustibleRespository : Repository<Combustible>, ICombustibleRepository
    {
        public CombustibleRespository(ApplicationDbContext db) : base(db) { }
    }
}
