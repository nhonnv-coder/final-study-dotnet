using FinalMvcNet.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalMvcNet.Models.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IFormFile? ImageFile { get; set; }

    public string? Image { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatus Status { get; set; }

    public List<SelectListItem> StatusOptions { get; } = Enum.GetValues(typeof(ProjectStatus))
        .Cast<ProjectStatus>()
        .Select(e => new SelectListItem
        {
            Value = ((int)e).ToString(),
            Text = e.ToString()
        })
        .ToList();
}
