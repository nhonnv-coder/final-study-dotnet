namespace FinalMvcNet.Data.Entities;

public enum ProjectStatus
{
    Inactive = 0,
    Active = 1,
}

public class Project : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
}
