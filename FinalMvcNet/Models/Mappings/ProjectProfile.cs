using AutoMapper;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;

namespace FinalMvcNet.Models.Mappings;

public class ProjectProfile: Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectViewModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        
        CreateMap<ProjectViewModel, Project>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
    }
}