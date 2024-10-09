using concesionarioAPI.Config;
using concesionarioAPI.Models.Auto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace concesionarioAPI.Repositories
{
    public interface IAutoRepository : IRepository<Auto> { }

    public class AutoRepository : Repository<Auto>, IAutoRepository
    {
        public AutoRepository(ApplicationDbContext db) : base(db) { }

        public new async Task<Auto>GetOne(Expression<Func<Auto, bool>>? filter = null)
        {
            IQueryable<Auto> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.Include(a => a.Combustible).FirstOrDefaultAsync();
        }
    }
}
