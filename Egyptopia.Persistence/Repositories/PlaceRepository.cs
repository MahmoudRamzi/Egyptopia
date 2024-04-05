using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.DTOs.Place;
using Egyptopia.Domain.DTOs.TourGuide;
using Egyptopia.Domain.DTOs.TourguideComment;
using Egyptopia.Domain.DTOs.TourguideLanuage;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Egyptopia.Persistence.Repositories
{
    internal class PlaceRepository : BaseRepository<Place>, IPlaceRepository
    {
        private readonly IImageRepository _imageRepository;
        private DataContext _context;
        public PlaceRepository(DataContext dataContext, IImageRepository imageRepository) : base(dataContext)
        {
            _context = dataContext;
            _imageRepository = imageRepository;
        }
        public async Task<List<Place>> GetAllPlacesDetailsByType (PlaceType type)

        {
            return await _context.Places.Include(x=>x.Governorate).Where(x=>x.PlaceType == type).ToListAsync();
        }
        public Place GetWithGovernorate(Guid id)
        {
            return _context.Places.Include(p => p.Governorate).FirstOrDefault(x=>x.Id == id);
        }
        public List<Place> GetAllWithGovernorate()
        {
            return _context.Places.Include(p => p.Governorate).ToList();
        }
        public List<PlaceResponseModel> Mapping(List<Place> places)
        {
            var placeDto = places
           .Select(h => new PlaceResponseModel
           {
               Id = h.Id,
               Name = h.Name,
               Location = h.Location,
               Description = h.Description,
               GovernorateId = h.GovernorateId,
               GovernorateName = h.Governorate.Name
           }).ToList();
            for (int i = 0; i < placeDto.Count; i++)
            {
                var images = _imageRepository.GetAll().Where(image => image.EntityId == placeDto[i].Id && image.ImageEntity == ImageEntity.Place)
                    .Select(h => new ImagDTO
                    {
                        Name = h.Name,
                    }).ToList();
                placeDto[i].Images = images;
            }
            return placeDto;
        }

    }
}