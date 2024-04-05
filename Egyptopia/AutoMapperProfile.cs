using AutoMapper;
using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;
using EgyptopiaApi.Models.Place;

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
            CreateMap<Hotel, HotelModel>();
            CreateMap<HotelModel, Hotel>();
            CreateMap<PlaceInputModel, Place>();
            CreateMap<Place, PlaceInputModel>();
            CreateMap<PlaceResponseModel, Place>();
            CreateMap<Place, PlaceResponseModel>();
            //CreateMap<BookingRoom, BookingRoomInputModel>();
            //CreateMap<BookingRoomInputModel, BookingRoom>();
            //CreateMap<BookingRoom, BookingRoomResponseModel>();
            //CreateMap<BookingRoomResponseModel, BookingRoom>();
            //CreateMap<BookingTourGuideResponse, BookingTourGuide>();
            //CreateMap<BookingTourGuide, BookingTourGuideResponse>();
            //CreateMap<BookingTourGuideInput, BookingTourGuide>();
            //CreateMap<BookingTourGuide, BookingTourGuideInput>();

            CreateMap<Image, ImageModel>();
            CreateMap<ImageModel, Image>()
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.File.FileName)); 




        }
    }
}
