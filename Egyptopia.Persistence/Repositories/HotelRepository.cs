using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Egyptopia.Domain.DTOs.HotelComment;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Egyptopia.Domain.DTOs.Paged;

namespace Egyptopia.Persistence.Repositories
{
    internal class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        private readonly DataContext _dataContext;

        public HotelRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Hotel> FilterByTerm(string term)
        {
            term = term.Trim().ToLower();
            //filtering record with name description location
            var hotels = _dataContext.Hotels.Include(h => h.HotelComments).Where(
                h => h.Name.ToLower().Contains(term)
                || h.Description.ToLower().Contains(term)
                || h.Location.ToLower().Contains(term));
            return hotels;
        }

        public async Task<List<Hotel>> GetAllWithComments()
        {
            return await _dataContext.Hotels.Include(h => h.HotelComments).ToListAsync();
        }

        public async Task<PagedHotelResult> GetAllWithFiltertion(string? term, string? sort, int page, int limit)
        {
            IQueryable<Hotel> hotels;
            if (string.IsNullOrWhiteSpace(term))
            {
                hotels = _dataContext.Hotels.Include(h => h.HotelComments);
            }
            else
            {
                //filtering records with name or description or location
                hotels = FilterByTerm(term);
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                string orderQuery = Sort(sort);
                if (!string.IsNullOrWhiteSpace(orderQuery))
                {
                    hotels = hotels.OrderBy(orderQuery);
                }
                else
                {
                    hotels = hotels.OrderBy(a => a.Id);
                }
            }

            //applay pagination
            return await Pagination(page,limit,hotels);
        }

        public async Task<Hotel> GetWithComments(Guid id)
        {
            return await _dataContext.Hotels.Include(h => h.HotelComments).FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<PagedHotelResult> Pagination(int page, int limit, IQueryable<Hotel> hotels)
        {
            var totalCount = await _dataContext.Hotels.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)limit);
            var pagedHotels = await hotels.Skip((page - 1) * limit).Take(limit).ToListAsync();
            var hotelsDto = pagedHotels
           .Select(h => new ReadHotel
           {
               Id = h.Id,
               Name = h.Name,
               Description = h.Description,
               Location = h.Location,
               Rate = CalculateRate((List<HotelComment>)h.HotelComments),
               Comments = h.HotelComments
                   .Select(c => new HotelCommentDTO
                   {
                       Comments = c.Comments,
                       PublishedDate = c.PublishedDate,
                       Rating = c.Rating,
                   }).ToList()
           }).ToList();
            var PagedHotelData = new PagedHotelResult
            {
                TotalPages = totalPages,
                TotalCount = totalCount,
                hotels = hotelsDto,
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

        public  int CalculateRate(List<HotelComment> comments)
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
    }
}