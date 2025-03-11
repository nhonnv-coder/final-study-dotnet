using AutoMapper;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;
using FinalMvcNet.Repositories.Sprints;

namespace FinalMvcNet.Services.Sprints;

public class SprintService : ISprintService
{
    private readonly ISprintRepository _sprintRepository;
    private readonly IMapper _mapper;

    public SprintService(ISprintRepository sprintRepository, IMapper mapper)
    {
        _sprintRepository = sprintRepository;
        _mapper = mapper;
    }

    public async Task<List<SprintViewModel>> GetAllAsync()
    {
        var sprints = await _sprintRepository.GetAllAsync();
        return _mapper.Map<List<SprintViewModel>>(sprints);
    }

    public async Task<SprintViewModel> GetByIdAsync(int id)
    {
        var sprint = await _sprintRepository.GetByIdAsync(id);
        return _mapper.Map<SprintViewModel>(sprint);
    }

    public async Task CreateAsync(SprintViewModel sprintViewModel)
    {
        var sprint = _mapper.Map<Sprint>(sprintViewModel);
        await _sprintRepository.AddAsync(sprint);
        await _sprintRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(SprintViewModel sprintViewModel)
    {
        var sprint = _mapper.Map<Sprint>(sprintViewModel);
        _sprintRepository.Update(sprint);
        await _sprintRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sprint = await _sprintRepository.GetByIdAsync(id);
        _sprintRepository.Remove(sprint);
        await _sprintRepository.SaveChangesAsync();
    }
}
