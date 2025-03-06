namespace FinalMvcNet.Data.Entities;

public class TestCase
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int TestSuiteId { get; set; }
    public TestSuite TestSuite { get; set; }
    public ICollection<TestStep> TestSteps { get; set; }
}