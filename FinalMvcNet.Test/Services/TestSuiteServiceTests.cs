using FinalMvcNet.Data.Entities;
using FinalMvcNet.Repositories.TestSuites;
using FinalMvcNet.Services.TestSuites;
using Moq;

namespace FinalMvcNet.Test.Services;

public class TestSuiteServiceTests
{
    private readonly Mock<ITestSuiteRepository> _mockRepository;
    private readonly TestSuiteService _testSuiteService;

    public TestSuiteServiceTests()
    {
        _mockRepository = new Mock<ITestSuiteRepository>();
        _testSuiteService = new TestSuiteService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturn_TestSuites()
    {
        var testSuites = new List<TestSuite>
        {
            new TestSuite { Id = 1, Name = "Suite 1" },
            new TestSuite { Id = 2, Name = "Suite 2" }
        };

        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(testSuites);

        var result = await _testSuiteService.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturn_Correct_TestSuite()
    {
        var testSuite = new TestSuite { Id = 1, Name = "Suite 1" };

        _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(testSuite);

        var result = await _testSuiteService.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCall_RepositoryUpdate()
    {
        var testSuite = new TestSuite { Id = 1, Name = "Updated Suite" };

        _mockRepository.Setup(r => r.UpdateAsync(testSuite)).Returns(Task.CompletedTask);

        await _testSuiteService.UpdateAsync(testSuite);

        _mockRepository.Verify(r => r.UpdateAsync(testSuite), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCall_RepositoryDelete()
    {
        _mockRepository.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);

        await _testSuiteService.DeleteAsync(1);

        _mockRepository.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task AddAsync_ShouldCall_RepositoryAdd()
    {
        var testSuite = new TestSuite { Id = 1, Name = "New Suite" };

        _mockRepository.Setup(r => r.AddAsync(testSuite)).Returns(Task.CompletedTask);

        await _testSuiteService.AddAsync(testSuite);

        _mockRepository.Verify(r => r.AddAsync(testSuite), Times.Once);
    }
}
