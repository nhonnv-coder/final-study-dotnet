using AutoMapper;
using FinalMvcNet.Data.Entities;
using FinalMvcNet.Models.ViewModels;

namespace FinalMvcNet.Models.Mappings;

public class TestSuiteProfile : Profile
{
    public TestSuiteProfile()
    {
        CreateMap<TestSuite, TestSuiteViewModel>()
            .ForMember(dest => dest.SprintName, opt => opt.MapFrom(src => src.Sprint.Name))
            .ReverseMap();
    }
}