using FinalMvcNet.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalMvcNet.Models.ViewModels;

public class SprintViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ProjectId { get; set; }
    
    public Project? Project { get; set; }
    
    public List<SelectListItem> ProjectOptions { get; set; } = new();
}