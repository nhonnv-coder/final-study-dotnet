using AutoMapper;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;
using FinalMvcNet.Repositories.Projects;
using FinalMvcNet.Services.File;

namespace FinalMvcNet.Services.Projects;

public class ProjectService: IProjectService
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IFileService _fileService;
    public ProjectService(IProjectRepository projectRepository, IFileService fileService, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async Task CreateProjectAsync(ProjectViewModel projectViewModel)
    {
        var project = _mapper.Map<Project>(projectViewModel);
        if (projectViewModel.ImageFile is not null)
        {
            project.Image = await _fileService.UploadImageAsync(projectViewModel.ImageFile);
        }

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();
    }

    public async Task<ProjectViewModel?> GetProjectByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        
        return _mapper.Map<ProjectViewModel>(project);
    }

    public Task UpdateProjectAsync(ProjectViewModel projectViewModel)
    {
        var project = _mapper.Map<Project>(projectViewModel);
        _projectRepository.Update(project);
        
        return _projectRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        var project = await _projectRepository.FindAsync(projectId);
        if (project == null)
        {
            return false;
        }

        _projectRepository.Remove(project);
        await _projectRepository.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _projectRepository.GetAllAsync();
    }
}