using FinalMvcNet.Data.Entities;

namespace FinalMvcNet.Repositories.TestSuites;

public interface ITestSuiteRepository
{
    Task<IEnumerable<TestSuite>> GetAllAsync();
    Task<TestSuite?> GetByIdAsync(int id);
    Task AddAsync(TestSuite testSuite);
    Task UpdateAsync(TestSuite testSuite);
    Task DeleteAsync(int id);
}