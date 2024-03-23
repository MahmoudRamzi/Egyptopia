using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    public class GovernorateRepository : BaseRepository<Governorate>, IGovernorateRepository
    {
        public GovernorateRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}