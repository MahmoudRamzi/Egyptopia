using Egyptopia.Domain.Entities;

namespace Egyptopia.Application.Repositories
{
    public interface IHotelRepository : IBaseRepository<Hotel> 
    {
        Hotel GetWithComments(Guid id);
        List<Hotel> GetAllWithComments();
    }
}