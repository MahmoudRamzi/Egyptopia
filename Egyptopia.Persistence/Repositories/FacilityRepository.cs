using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    public class FacilityRepository : BaseRepository<Facility>, IFacilityRepository
    {
        public FacilityRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}