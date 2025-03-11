using FinalMvcNet.Data.Entities;

namespace FinalMvcNet.Services.TestSuites;

public interface ITestSuiteService
{
    Task<IEnumerable<TestSuite>> GetAllAsync();
    Task<TestSuite?> GetByIdAsync(int id);
    Task UpdateAsync(TestSuite testSuite);
    Task DeleteAsync(int id);
    Task AddAsync(TestSuite testSuite);
}