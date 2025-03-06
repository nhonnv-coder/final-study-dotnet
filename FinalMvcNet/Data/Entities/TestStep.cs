namespace FinalMvcNet.Data.Entities;

public class TestStep
{
    public int Id { get; set; }
    public string Action { get; set; }
    public string ExpectedResult { get; set; }
    public int TestCaseId { get; set; }
    public TestCase TestCase { get; set; }
}