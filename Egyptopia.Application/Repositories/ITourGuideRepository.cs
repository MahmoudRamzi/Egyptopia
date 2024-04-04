using Egyptopia.Domain.DTOs.Paged;
using Egyptopia.Domain.DTOs.TourGuide;
using Egyptopia.Domain.Entities;

namespace Egyptopia.Application.Repositories
{
    public interface ITourGuideRepository : IBaseRepository<TourGuide>
    {
        Task<TourGuide> GetWithCommentsAndLanguages(Guid id);
        Task<List<TourGuide>> GetAllWithCommentsAndLanguages();
        Task<PagedTourGuideResult> GetAllWithFiltertion(string? term, string? sort, int page, int limit);
        IQueryable<TourGuide> FilterByTerm(string term);
        Task<PagedTourGuideResult> Pagination(int page, int limit, IQueryable<TourGuide> hotels);
        List<ReadTourGuide> Mapping(List<TourGuide> tourGuides);
    }
}