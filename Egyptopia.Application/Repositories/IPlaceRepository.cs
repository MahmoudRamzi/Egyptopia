using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;

namespace Egyptopia.Application.Repositories
{
    public interface IPlaceRepository : IBaseRepository<Place>
    {
        Task<List<Place>> GetAllPlacesDetailsByType(PlaceType type);
    }
}