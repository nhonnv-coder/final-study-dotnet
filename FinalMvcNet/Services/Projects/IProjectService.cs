using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;

namespace FinalMvcNet.Services.Projects;

public interface IProjectService
{
    public Task CreateProjectAsync(ProjectViewModel projectViewModel);
    public Task<ProjectViewModel?> GetProjectByIdAsync(int id);
    Task UpdateProjectAsync(ProjectViewModel projectViewModel);
    Task<bool> DeleteProjectAsync(int id);
    Task<IEnumerable<Project>> GetAllAsync();
}
