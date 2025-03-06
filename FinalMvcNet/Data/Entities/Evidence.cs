namespace FinalMvcNet.Data.Entities;

public class Evidence
{
    public int Id { get; set; }
    public int TestRunId { get; set; }
    public TestRun TestRun { get; set; }
    public string FilePath { get; set; }
}
