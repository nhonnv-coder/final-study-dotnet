using AutoMapper;
using Moq;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;
using FinalMvcNet.Repositories.Projects;
using FinalMvcNet.Services.File;
using FinalMvcNet.Services.Projects;

namespace FinalMvcNet.Test.Services;

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _mockProjectRepo;
    private readonly Mock<IFileService> _mockFileService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ProjectService _projectService;

    public ProjectServiceTests()
    {
        _mockProjectRepo = new Mock<IProjectRepository>();
        _mockFileService = new Mock<IFileService>();
        _mockMapper = new Mock<IMapper>();

        _projectService = new ProjectService(
            _mockProjectRepo.Object,
            _mockFileService.Object,
            _mockMapper.Object
        );
    }

    [Fact]
    public async Task CreateProjectAsync_Should_Add_Project()
    {
        var projectViewModel = new ProjectViewModel { Name = "Test Project" };
        var project = new Project { Id = 1, Name = "Test Project" };

        _mockMapper.Setup(m => m.Map<Project>(projectViewModel)).Returns(project);
        _mockProjectRepo.Setup(r => r.AddAsync(project)).Returns(Task.CompletedTask);
        _mockProjectRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        await _projectService.CreateProjectAsync(projectViewModel);

        _mockProjectRepo.Verify(r => r.AddAsync(It.IsAny<Project>()), Times.Once);
        _mockProjectRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task GetProjectByIdAsync_Should_Return_Correct_Project()
    {
        int projectId = 1;
        var project = new Project { Id = projectId, Name = "Test Project" };
        var projectViewModel = new ProjectViewModel { Id = projectId, Name = "Test Project" };

        _mockProjectRepo.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
        _mockMapper.Setup(m => m.Map<ProjectViewModel>(project)).Returns(projectViewModel);

        var result = await _projectService.GetProjectByIdAsync(projectId);

        Assert.NotNull(result);
        Assert.Equal(projectId, result.Id);
        Assert.Equal("Test Project", result.Name);
    }

    [Fact]
    public async Task UpdateProjectAsync_Should_Update_Project()
    {
        var projectViewModel = new ProjectViewModel { Id = 1, Name = "Updated Project" };
        var project = new Project { Id = 1, Name = "Original Project" };

        _mockMapper.Setup(m => m.Map<Project>(projectViewModel)).Returns(project);
        _mockProjectRepo.Setup(r => r.Update(project));
        _mockProjectRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        await _projectService.UpdateProjectAsync(projectViewModel);

        _mockProjectRepo.Verify(r => r.Update(It.IsAny<Project>()), Times.Once);
        _mockProjectRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteProjectAsync_Should_Delete_Existing_Project()
    {
        int projectId = 1;
        var project = new Project { Id = projectId, Name = "Test Project" };

        _mockProjectRepo.Setup(r => r.FindAsync(projectId)).ReturnsAsync(project);
        _mockProjectRepo.Setup(r => r.Remove(project));
        _mockProjectRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        var result = await _projectService.DeleteProjectAsync(projectId);

        Assert.True(result);
        _mockProjectRepo.Verify(r => r.Remove(It.IsAny<Project>()), Times.Once);
        _mockProjectRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteProjectAsync_Should_Return_False_When_Project_Not_Found()
    {
        int projectId = 1;

        _mockProjectRepo.Setup(r => r.FindAsync(projectId)).ReturnsAsync((Project)null);

        var result = await _projectService.DeleteProjectAsync(projectId);

        Assert.False(result);
        _mockProjectRepo.Verify(r => r.Remove(It.IsAny<Project>()), Times.Never);
        _mockProjectRepo.Verify(r => r.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_List_Of_Projects()
    {
        var projects = new List<Project>
        {
            new Project { Id = 1, Name = "Project 1" },
            new Project { Id = 2, Name = "Project 2" }
        };

        var projectViewModels = new List<ProjectViewModel>
        {
            new ProjectViewModel { Id = 1, Name = "Project 1" },
            new ProjectViewModel { Id = 2, Name = "Project 2" }
        };

        _mockProjectRepo.Setup(r => r.GetAllAsync(true)).ReturnsAsync(projects);
        _mockMapper.Setup(m => m.Map<IEnumerable<ProjectViewModel>>(projects)).Returns(projectViewModels);

        var result = await _projectService.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}