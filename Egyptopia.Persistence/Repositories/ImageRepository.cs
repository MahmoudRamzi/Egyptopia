using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    internal class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}