using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.DTOs.HotelComment;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        public HotelController(
            IHotelRepository hotelRepository,
            IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        [HttpPost(nameof(CreateHotel))]
        public ActionResult<Hotel> CreateHotel(WriteHotel writeHotel)
        {
            var hotel = new Hotel
            {
                Name = writeHotel.Name,
                Location = writeHotel.Location,
                Description = writeHotel.Description,
            };
            var data = _hotelRepository.Create(hotel);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        //[Authorize]
        [HttpGet(nameof(GetAllHotel))]
        public ActionResult<List<ReadHotel>> GetAllHotel()
        {
            var hotels = _hotelRepository.GetAllWithComments();
            if (hotels == null)
            {
                return NotFound();
            }
            var hotelsDto = hotels
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
            return Ok(hotelsDto);
        }

        [HttpGet(nameof(GetHotel))]
        public ActionResult<ReadHotel> GetHotel(Guid id)
        {
            var hotel = _hotelRepository.GetWithComments(id);
            if (hotel == null)
            {
                return NotFound();
            }
            var hotelDTo = new ReadHotel
            {
                Id= hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                Location = hotel.Location,
                Rate = CalculateRate(hotel.HotelComments),
                Comments = hotel.HotelComments
                  .Select(c => new HotelCommentDTO
                  {
                      Comments = c.Comments,
                      PublishedDate = c.PublishedDate,
                      Rating = c.Rating,
                  }).ToList()
            };
            return Ok(hotelDTo);
        }

        [HttpPut(nameof(UpdateHotel))]
        public ActionResult<HotelModel?> UpdateHotel(HotelModel model)
        {
            if (model == null)
                return BadRequest();
            var entity = _hotelRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_hotelRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteHotel))]
        public ActionResult DeleteHotel(Guid id)
        {
            var entity = _hotelRepository.Get(id);
            if (entity == null)
                return NotFound();

            _hotelRepository.Delete(entity);
            return Ok();
        }
        [HttpGet(nameof(GetAllWithFiltertion))]
        public async Task<ActionResult<List<ReadHotel>>> GetAllWithFiltertion(string? term, string? sort, int page=1, int limit = 5)
        {
            var hotelResult = await _hotelRepository.GetAllWithFiltertion(term, sort, page, limit);
            //add pagination header to the response
            Response.Headers.Add("Hotels-Total-Count",hotelResult.TotalCount.ToString());
            Response.Headers.Add("Hotels-Total-Pages", hotelResult.TotalPages.ToString());
            return Ok(hotelResult.hotels);

        }
        public static int CalculateRate(List<HotelComment> comments)
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