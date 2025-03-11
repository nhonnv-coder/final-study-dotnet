namespace FinalMvcNet.Data.Entities;

public class TestSuite: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SprintId { get; set; }
    public Sprint Sprint { get; set; }
    public ICollection<TestCase> TestCases { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}