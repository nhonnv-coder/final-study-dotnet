namespace FinalMvcNet.Data.Entities;

public enum TestRunStatus
{
    Pending,
    Skip,
    Warning,
    Fail,
    Pass
}

public class TestRun
{
    public int Id { get; set; }
    public int TestCaseId { get; set; }
    public TestCase TestCase { get; set; }
    public TestRunStatus Status { get; set; }
    public DateTime RunDate { get; set; }
    public ICollection<Evidence> Evidences { get; set; }
}