
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Egyptopia.Application.Repositories;

namespace Egyptopia.Persistence.Repositories
{
    public class GovernorateRepository : BaseRepository<Governorate>,IGovernorateRepository
    {
        public GovernorateRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
