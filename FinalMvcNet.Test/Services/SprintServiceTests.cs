using AutoMapper;
using Moq;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;
using FinalMvcNet.Repositories.Sprints;
using FinalMvcNet.Services.Sprints;

namespace FinalMvcNet.Test.Services;

public class SprintServiceTests
{
    private readonly Mock<ISprintRepository> _mockSprintRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly SprintService _sprintService;

    public SprintServiceTests()
    {
        _mockSprintRepo = new Mock<ISprintRepository>();
        _mockMapper = new Mock<IMapper>();
        _sprintService = new SprintService(_mockSprintRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_List_Of_Sprints()
    {
        var sprints = new List<Sprint> { new Sprint { Id = 1, Name = "Sprint 1" } };
        var sprintViewModels = new List<SprintViewModel> { new SprintViewModel { Id = 1, Name = "Sprint 1" } };
        
        _mockSprintRepo.Setup(r => r.GetAllAsync(true)).ReturnsAsync(sprints);
        _mockMapper.Setup(m => m.Map<List<SprintViewModel>>(sprints)).Returns(sprintViewModels);
        
        var result = await _sprintService.GetAllAsync();
        
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Sprint 1", result[0].Name);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_Correct_Sprint()
    {
        var sprint = new Sprint { Id = 1, Name = "Sprint 1" };
        var sprintViewModel = new SprintViewModel { Id = 1, Name = "Sprint 1" };
        
        _mockSprintRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(sprint);
        _mockMapper.Setup(m => m.Map<SprintViewModel>(sprint)).Returns(sprintViewModel);
        
        var result = await _sprintService.GetByIdAsync(1);
        
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Sprint 1", result.Name);
    }

    [Fact]
    public async Task CreateAsync_Should_Add_Sprint()
    {
        var sprintViewModel = new SprintViewModel { Name = "New Sprint" };
        var sprint = new Sprint { Name = "New Sprint" };
        
        _mockMapper.Setup(m => m.Map<Sprint>(sprintViewModel)).Returns(sprint);
        _mockSprintRepo.Setup(r => r.AddAsync(sprint)).Returns(Task.CompletedTask);
        _mockSprintRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);
        
        await _sprintService.CreateAsync(sprintViewModel);
        
        _mockSprintRepo.Verify(r => r.AddAsync(It.IsAny<Sprint>()), Times.Once);
        _mockSprintRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Sprint()
    {
        var sprintViewModel = new SprintViewModel { Id = 1, Name = "Updated Sprint" };
        var sprint = new Sprint { Id = 1, Name = "Old Sprint" };
        
        _mockMapper.Setup(m => m.Map<Sprint>(sprintViewModel)).Returns(sprint);
        _mockSprintRepo.Setup(r => r.Update(sprint));
        _mockSprintRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);
        
        await _sprintService.UpdateAsync(sprintViewModel);
        
        _mockSprintRepo.Verify(r => r.Update(It.IsAny<Sprint>()), Times.Once);
        _mockSprintRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_Should_Delete_Sprint()
    {
        var sprint = new Sprint { Id = 1, Name = "Sprint 1" };
        
        _mockSprintRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(sprint);
        _mockSprintRepo.Setup(r => r.Remove(sprint));
        _mockSprintRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);
        
        await _sprintService.DeleteAsync(1);
        
        _mockSprintRepo.Verify(r => r.Remove(It.IsAny<Sprint>()), Times.Once);
        _mockSprintRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
