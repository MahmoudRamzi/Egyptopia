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
CreateMap<TourGuideRead, TourGuide>();
CreateMap<TourGuideRead, TourGuide>();
            CreateMap<TourGuideModell, TourGuide>();
            CreateMap<TourGuide, TourGuideModell>();
            CreateMap<FacilityModel, Facility>();
            CreateMap<Facility, FacilityModel>();
        
            CreateMap<Room, RoomInputModel>();
            CreateMap<RoomInputModel, Room>();
            CreateMap<Room, RoomResponseModel>();
            CreateMap<RoomResponseModel, Room>();
            CreateMap<Hotel, HotelModel>();
            CreateMap<HotelModel, Hotel>();
            CreateMap<PlaceInputModel, Place>();
            CreateMap<Place, PlaceInputModel>();
            CreateMap<PlaceResponseModel, Place>();
            CreateMap<Place, PlaceResponseModel>();
            CreateMap<BookingRoom, BookingRoomInputModel>();
            CreateMap<BookingRoomInputModel, BookingRoom>();
            CreateMap<BookingRoom, BookingRoomResponseModel>();
            CreateMap<BookingRoomResponseModel, BookingRoom>();
            CreateMap<BookingTourGuideResponseModel, BookingTourGuide>();
            CreateMap<BookingTourGuide, BookingTourGuideResponseModel>();
            CreateMap<BookingTourGuideInputModel, BookingTourGuide>();
            CreateMap<BookingTourGuide, BookingTourGuideInputModel>();

            CreateMap<Image, ImageModel>();
            CreateMap<ImageModel, Image>()
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.File.FileName)); 




        }
    }
}
