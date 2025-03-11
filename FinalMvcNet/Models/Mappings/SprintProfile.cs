using AutoMapper;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;

namespace FinalMvcNet.Models.Mappings;

public class SprintProfile: Profile
{
    public SprintProfile()
    {
        CreateMap<Sprint, SprintViewModel>();
        CreateMap<SprintViewModel, Sprint>();
    }
}