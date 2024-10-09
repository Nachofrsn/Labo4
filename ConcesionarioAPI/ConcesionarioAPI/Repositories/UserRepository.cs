using concesionarioAPI.Config;
using concesionarioAPI.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace concesionarioAPI.Repositories
{
    public interface IUserRepository : IRepository<User> { }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db) { }
    }
}
