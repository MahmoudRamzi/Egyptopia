﻿using Egyptopia.Domain.DTOs.Paged;
using Egyptopia.Domain.Entities;

namespace Egyptopia.Application.Repositories
{
    public interface IHotelRepository : IBaseRepository<Hotel> 
    {
        Hotel GetWithComments(Guid id);
        List<Hotel> GetAllWithComments();
        Task<PagedHotelResult> GetAllWithFiltertion(string? term , string? sort , int page , int limit);
        IQueryable<Hotel> FilterByTerm(string term);
        Task<PagedHotelResult> Pagination(int page, int limit, IQueryable<Hotel> hotels);
    }
}