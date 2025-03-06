namespace FinalMvcNet.Data.Entities;

public class TestSuite
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SprintId { get; set; }
    public Sprint Sprint { get; set; }
    public ICollection<TestCase> TestCases { get; set; }
}