using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName ="Room")]

    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomController(
            IRoomRepository roomRepository,
            IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        [HttpPost(nameof(CreateRoom))]
        public ActionResult<RoomModel?> CreateRoom(RoomModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = _roomRepository.Create(_mapper.Map<Room>(model));
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        //[Authorize]
        [HttpGet(nameof(GetAllRoom))]
        public ActionResult<List<RoomModel>> GetAllRoom()
        {
            return Ok(_mapper.Map<List<RoomModel>>(_roomRepository.GetAll()));
        }

        [HttpGet(nameof(GetRoom))]
        public ActionResult<RoomModel?> GetRoom(Guid id)
        {
            return Ok(_mapper.Map<RoomModel>(_roomRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateRoom))]
        public ActionResult<RoomModel?> UpdateRoom(RoomModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model == null)
                return BadRequest();
            var entity = _roomRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_roomRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteRoom))]
        public ActionResult DeleteRoom(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id cant be empty");
            }
            var entity = _roomRepository.Get(id);
            if (entity == null)
                return NotFound();

            _roomRepository.Delete(entity);
            return Ok();
        }
        [HttpGet("GetRoomsByHotel/{hotelId}")]
        public ActionResult<List<RoomModel>> GetRoomsByHotel(Guid hotelId)
        {
            if (hotelId == Guid.Empty)
            {
                return BadRequest("Hotel ID cannot be empty.");
            }

            var rooms = _roomRepository.GetAll()
                .Where(room => room.HotelId == hotelId)
                .ToList();

            if (rooms == null || !rooms.Any())
            {
                return NotFound("No rooms found for the given hotel ID.");
            }

            return Ok(_mapper.Map<List<RoomModel>>(rooms));
        }

    }
}