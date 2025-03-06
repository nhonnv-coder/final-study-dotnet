namespace FinalMvcNet.Data.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Sprint> Sprints { get; set; }
}
