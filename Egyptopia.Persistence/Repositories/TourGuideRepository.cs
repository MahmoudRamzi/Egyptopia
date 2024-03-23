using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    internal class TourGuideRepository : BaseRepository<TourGuide>, ITourGuideRepository
    {
        public TourGuideRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}