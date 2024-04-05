using Egyptopia.Domain.DTOs.Place;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;

namespace Egyptopia.Application.Repositories
{
    public interface IPlaceRepository : IBaseRepository<Place>
    {
        Task<List<Place>> GetAllPlacesDetailsByType(PlaceType type);
        List<PlaceResponseModel> Mapping(List<Place> places);
        Place GetWithGovernorate(Guid id);
        List<Place> GetAllWithGovernorate();
    }
}