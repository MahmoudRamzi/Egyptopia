using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Egyptopia.Application.Repositories;
using System;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        [HttpPost(nameof(CreateHotel))]
        public ActionResult<Hotel?> CreateHotel(Hotel hotel)
        {
            var data = _hotelRepository.Create(hotel);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        [HttpGet(nameof(GetAllHotels))]
        public ActionResult<Hotel?> GetAllHotels()
        {
            return Ok(_hotelRepository.GetAll());
        }
        [HttpGet(nameof(GetHotel))]
        public ActionResult<Hotel?> GetHotel(Guid id)
        {
            return Ok(_hotelRepository.Get(id));
        }
        [HttpPut(nameof(UpdateHotel))]
        public ActionResult<Hotel?> UpdateHotel(Hotel hotel)
        {
            if (hotel == null)
                return BadRequest();
            return Ok(_hotelRepository.Update(hotel));
        }
        [HttpDelete(nameof(DeleteHotel))]
        public void DeleteHotel(Guid id)
        {
            _hotelRepository.Delete(id);
        }
    }
}
