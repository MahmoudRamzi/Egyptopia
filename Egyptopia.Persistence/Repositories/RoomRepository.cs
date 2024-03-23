using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    internal class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}