using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Persistence.Repositories
{
    public class UserExperienceRepository : BaseRepository<UserExprience>, IUserExperienceRepository
    {
        private readonly DataContext _dataContext;
        public UserExperienceRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public List<UserExprience> GetAllWithUser()
        {
            return _dataContext.UserExpriences.Include(u => u.ApplicationUser).ToList();
        }
    }
}
