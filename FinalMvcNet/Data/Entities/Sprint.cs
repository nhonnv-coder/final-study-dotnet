using System.ComponentModel.DataAnnotations.Schema;

namespace FinalMvcNet.Data.Entities;

public class Sprint: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    [ForeignKey("ProjectId")]
    public int ProjectId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Project Project { get; set; }
    public ICollection<TestSuite> TestSuites { get; set; }
}