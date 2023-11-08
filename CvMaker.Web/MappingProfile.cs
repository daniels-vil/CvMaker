using AutoMapper;
using CvMaker.Core.Models;
using CvMaker.Web.Models;

namespace CvMaker.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurriculumVitae, CvItemModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.OtherName, opt => opt.MapFrom(src => src.OtherName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.LanguageKnowledge, opt => opt.MapFrom(src => src.Languages))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
                .ForMember(dest => dest.Educations, opt => opt.MapFrom(src => src.Educations))
                .ForMember(dest => dest.Employments, opt => opt.MapFrom(src => src.Employments))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<LanguageKnowledge, LanguageKnowledgeViewModel>().ReverseMap();
            CreateMap<Skills, SkillsViewModel>().ReverseMap();
            CreateMap<Education, EducationViewModel>().ReverseMap();
            CreateMap<Employment, EmploymentViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
        }
    }
}
