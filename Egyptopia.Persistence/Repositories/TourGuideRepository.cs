using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.DTOs.HotelComment;
using Egyptopia.Domain.DTOs.Paged;
using Egyptopia.Domain.DTOs.TourGuide;
using Egyptopia.Domain.DTOs.TourguideComment;
using Egyptopia.Domain.DTOs.TourguideLanuage;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Egyptopia.Persistence.Repositories
{
    internal class TourGuideRepository : BaseRepository<TourGuide>, ITourGuideRepository
    {
        private readonly DataContext _dataContext;
        public TourGuideRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<TourGuide> FilterByTerm(string term)
        {
            term = term.Trim().ToLower();
            //filtering record with name description location
            var tourGuides = _dataContext.TourGuids
                .Include(t => t.TourGuideComments)
                .Include(t => t.TourGuideLanguages)
                .ThenInclude(t => t.Language).Where(
                h => h.Name.ToLower().Contains(term)
                || h.Price.ToString().ToLower().Contains(term)
                || h.Location.ToLower().Contains(term)
                || h.TourGuideLanguages.Any(t => t.Language.Name.ToLower().Contains(term))
                || h.AboutInfo.ToLower().Contains(term));
            return tourGuides;
        }

        public async Task<List<TourGuide>> GetAllWithCommentsAndLanguages()
        {
            return await _dataContext.TourGuids.Include(t => t.TourGuideComments).Include(t => t.TourGuideLanguages).ThenInclude(l => l.Language).ToListAsync();
        }

        public async Task<PagedTourGuideResult> GetAllWithFiltertion(string? term, string? sort, int page, int limit)
        {
            IQueryable<TourGuide> tourGuide;
            if (string.IsNullOrEmpty(term))
            {
                tourGuide = _dataContext.TourGuids.Include(t => t.TourGuideComments).Include(t => t.TourGuideLanguages).ThenInclude(l => l.Language);
            }
            else
            {
                //filtering records with name or description or location
                tourGuide = FilterByTerm(term);
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                string orderQuery = Sort(sort);
                if (!string.IsNullOrWhiteSpace(orderQuery))
                {
                    tourGuide = tourGuide.OrderBy(orderQuery);
                }
                else
                {
                    tourGuide = tourGuide.OrderBy(a => a.Id);
                }
            }

            //applay pagination
            return await Pagination(page, limit, tourGuide);
        }

        public async Task<TourGuide> GetWithCommentsAndLanguages(Guid id)
        {
            return await _dataContext.TourGuids.Include(t => t.TourGuideComments).Include(t => t.TourGuideLanguages).ThenInclude(l => l.Language).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<PagedTourGuideResult> Pagination(int page, int limit, IQueryable<TourGuide> tourGuides)
        {
            var totalCount = await _dataContext.TourGuids.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)limit);
            var pagedTourGuides = await tourGuides.Skip((page - 1) * limit).Take(limit).ToListAsync();
            var tourGuidesDto = Mapping(pagedTourGuides);
            var PagedHotelData = new PagedTourGuideResult
            {
                TotalPages = totalPages,
                TotalCount = totalCount,
                tourGuides = tourGuidesDto,
            };
            return PagedHotelData;
        }

        public string Sort(string sort)
        {
            var sortFields = sort.Split(',');
            StringBuilder orderQueryBuilder = new StringBuilder();
            //using reflection to get props of book
            PropertyInfo[] propertyInfo = typeof(Hotel).GetProperties();
            foreach (var field in sortFields)
            {
                string sortOrder = "ascending";
                var sortField = field.Trim();
                if (sortField.StartsWith("-"))
                {
                    sortField = sortField.TrimStart('-');
                    sortOrder = "descending";
                }
                var property = propertyInfo.FirstOrDefault(x =>
                  x.Name.Equals(sortField,
                  StringComparison.OrdinalIgnoreCase));

                if (property == null)
                {
                    continue;
                }
                else
                {
                    orderQueryBuilder.Append($"{property.Name.ToString()} {sortOrder}, ");
                }
            }
            string orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return orderQuery;
        }

        public int CalculateRate(List<TourGuideComment> comments)
        {
            if (comments.Count > 0)
            {
                return (comments.Sum(s => s.Rating) / comments.Count);
            }
            else
            {
                return 0;
            }
        }
        public static string TotalReviews(List<TourGuideComment> comments)
        {
            if (comments.Count > 0)
            {
                return $"{comments.Count} Reviews";
            }
            else
            {
                return "Be the first to comment.";
            }
        }

        public List<ReadTourGuide> Mapping(List<TourGuide> tourGuides)
        {
            var tourGuidesDto = tourGuides
           .Select(h => new ReadTourGuide
           {
               Id = h.Id,
               Name = h.Name,
               Price = h.Price,
               Location = h.Location,
               AboutInfo = h.AboutInfo,
               Rate = CalculateRate((List<TourGuideComment>)h.TourGuideComments),
               Comments = h.TourGuideComments
                   .Select(c => new TourGuideCommentDTO
                   {
                       Comments = c.Comments,
                       PublishedDate = c.PublishedDate,
                       Rating = c.Rating,
                   }).ToList(),
               Languages = h.TourGuideLanguages
                    .Select(l => new TourGuideLanguageDTO
                    {
                        LanguageName = l.Language.Name
                    }).ToList(),
               TotalReviews = TotalReviews((List<TourGuideComment>)h.TourGuideComments)
           }).ToList();
            return tourGuidesDto;
        }
    }
}