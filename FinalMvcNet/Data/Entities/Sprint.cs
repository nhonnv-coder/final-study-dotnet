namespace FinalMvcNet.Data.Entities;

public class Sprint
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public ICollection<TestSuite> TestSuites { get; set; }
}