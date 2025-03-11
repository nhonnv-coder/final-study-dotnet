using FinalMvcNet.Data;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalMvcNet.Repositories.TestSuites;

public class TestSuiteRepository : Repository<TestSuite>, ITestSuiteRepository
{
    public TestSuiteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<TestSuite>> GetAllAsync()
    {
        return await _entities
            .Include(ts => ts.Sprint)
            .ToListAsync();
    }
    
    public async Task<TestSuite?> GetByIdAsync(int id)
    {
        return await _entities
            .Include(ts => ts.Sprint)
            .FirstOrDefaultAsync(ts => ts.Id == id);
    }
    
    public async Task UpdateAsync(TestSuite testSuite)
    {
        _entities.Update(testSuite);
        await SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var testSuite = await GetByIdAsync(id);
        if (testSuite != null)
        {
            _entities.Remove(testSuite);
            await SaveChangesAsync();
        }
    }
}