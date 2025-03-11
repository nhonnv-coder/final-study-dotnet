using FinalMvcNet.Data;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalMvcNet.Repositories.Sprints;

public class SprintRepository : Repository<Sprint>, ISprintRepository
{
    public SprintRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Sprint>> GetAllSprints()
    {
        return await _entities.Include(e => e.Project).ToListAsync();
    }
}