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
    internal class HotelRepository:BaseRepository<Hotel>,IHotelRepository
    {
        public HotelRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
