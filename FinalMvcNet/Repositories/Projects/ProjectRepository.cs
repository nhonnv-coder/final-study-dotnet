using FinalMvcNet.Data;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Repositories.Base;

namespace FinalMvcNet.Repositories.Projects;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
