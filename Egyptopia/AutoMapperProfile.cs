using AutoMapper;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;

namespace EgyptopiaApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Governorate, GovernorateModel>();            
            CreateMap<GovernorateModel, Governorate>();


            CreateMap<Image, ImageModel>();
            CreateMap<ImageModel, Image>()
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.File.FileName)); 



        }
    }
}
