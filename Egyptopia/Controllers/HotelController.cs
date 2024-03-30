using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<HotelModel?> CreateHotel(HotelModel model)
        {
            var data = _hotelRepository.Create(_mapper.Map<Hotel>(model));
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        //[Authorize]
        [HttpGet(nameof(GetAllHotel))]
        public ActionResult<List<HotelModel>> GetAllHotel()
        {
            return Ok(_mapper.Map<List<HotelModel>>(_hotelRepository.GetAll()));
        }

        [HttpGet(nameof(GetHotel))]
        public ActionResult<HotelModel?> GetHotel(Guid id)
        {
            return Ok(_mapper.Map<HotelModel>(_hotelRepository.Get(id)));
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
    }
}