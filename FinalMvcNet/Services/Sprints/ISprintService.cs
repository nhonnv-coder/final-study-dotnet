using FinalMvcNet.Models.ViewModels;

namespace FinalMvcNet.Services.Sprints;

public interface ISprintService
{
    Task<List<SprintViewModel>> GetAllAsync();
    Task<SprintViewModel> GetByIdAsync(int id);
    Task CreateAsync(SprintViewModel sprintViewModel);
    Task UpdateAsync(SprintViewModel sprintViewModel);
    Task DeleteAsync(int id);
}
