using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Persistence.Repositories
{
    internal class TourGuideServiceRepository:BaseRepository<TourGuideService>,ITourGuideServiceRepository
    {
        public TourGuideServiceRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
