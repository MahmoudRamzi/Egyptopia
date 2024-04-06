using Egyptopia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptopia.Application.Repositories
{
    public interface IUserExperienceRepository:IBaseRepository<UserExprience>
    {
        List<UserExprience> GetAllWithUser();
    }
}
