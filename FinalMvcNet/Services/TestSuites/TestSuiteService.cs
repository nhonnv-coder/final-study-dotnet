using FinalMvcNet.Data.Entities;
using FinalMvcNet.Repositories.TestSuites;

namespace FinalMvcNet.Services.TestSuites;

public class TestSuiteService : ITestSuiteService
{
    private readonly ITestSuiteRepository _repository;

    public TestSuiteService(ITestSuiteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TestSuite>> GetAllAsync() => await _repository.GetAllAsync();
    
    public async Task<TestSuite?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(TestSuite testSuite) => await _repository.UpdateAsync(testSuite);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    public Task AddAsync(TestSuite testSuite) => _repository.AddAsync(testSuite);
}