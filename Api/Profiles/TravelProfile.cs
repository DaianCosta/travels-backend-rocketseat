using System.Linq;
using AutoMapper;

namespace Api.Profiles
{
    public class TravelProfile : Profile
    {
        public TravelProfile()
        {   
            CreateMap<Entities.Travel, Models.GetTravel>()
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date.ToString("yyyy/MM/dd")))
                .ForMember(
                    dest => dest.DateRegister,
                    opt => opt.MapFrom(src => src.DateRegister.ToString("yyyy/MM/dd HH:mm:ss")));

            CreateMap<Entities.Travel, Models.GetTravelMetadata>();
            CreateMap<Entities.PageList<Entities.Travel>, Models.GetTravelMetadata>()
            .ForPath(
                    dest => dest.metadata.Page.Limit,
                    opt => opt.MapFrom(src => src.Limit))
                .ForPath(
                    dest => dest.metadata.Page.PreviousPage,
                    opt => opt.MapFrom(src => src.PreviousPage))
                .ForPath(
                    dest => dest.metadata.Page.Page,
                    opt => opt.MapFrom(src => src.Page))
                .ForPath(
                    dest => dest.metadata.Page.NextPage,
                    opt => opt.MapFrom(src => src.NextPage))
                .ForPath(
                    dest => dest.metadata.Page.TotalItems,
                    opt => opt.MapFrom(src => src.TotalItems))
                .ForPath(
                    dest => dest.metadata.Page.TotalPages,
                    opt => opt.MapFrom(src => src.TotalPages))
                .ForPath(
                    dest => dest.results,
                    opt => opt.MapFrom(src => src.Items));
        }
    }
}