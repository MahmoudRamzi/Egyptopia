using AutoMapper;
using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;

namespace EgyptopiaApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {CreateMap<Governorate, GovernorateModel>();            
CreateMap<GovernorateModel, Governorate>();
CreateMap<TourGuide, TourGuideModel>();
CreateMap<TourGuideModel, TourGuide>();
CreateMap<Room, RoomModel>();
CreateMap<RoomModel, Room>();


            CreateMap<Image, ImageModel>();
            CreateMap<ImageModel, Image>()
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.File.FileName)); 




        }
    }
}
