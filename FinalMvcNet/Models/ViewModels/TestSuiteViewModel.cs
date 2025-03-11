using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalMvcNet.Models.ViewModels;

public class TestSuiteViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int SprintId { get; set; }
    public string SprintName { get; set; }

    public List<SelectListItem> SprintOptions { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}