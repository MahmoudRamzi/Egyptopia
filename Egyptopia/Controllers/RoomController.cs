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
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomController(
            IRoomRepository roomRepository,
            IMapper mapper)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost(nameof(CreateRoom))]
        public ActionResult<RoomResponseModel> CreateRoom(RoomInputModel model)
        {
            if (model == null)
            {
                return BadRequest("Model is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomEntity = _mapper.Map<Room>(model);
            var createdRoom = _roomRepository.Create(roomEntity);

            var responseModel = _mapper.Map<RoomResponseModel>(createdRoom);

            return CreatedAtAction(nameof(GetRoom), new { id = responseModel.Id }, responseModel);
        }

        [HttpGet(nameof(GetAllRoom))]
        public ActionResult<List<RoomResponseModel>> GetAllRoom()
        {
            var rooms = _roomRepository.GetAll();
            var responseModels = _mapper.Map<List<RoomResponseModel>>(rooms);
            return Ok(responseModels);
        }

        [HttpGet(nameof(GetRoom))]
        public ActionResult<RoomResponseModel> GetRoom(Guid id)
        {
            var room = _roomRepository.Get(id);
            if (room == null)
                return NotFound();

            var responseModel = _mapper.Map<RoomResponseModel>(room);
            return Ok(responseModel);
        }

        [HttpPut(nameof(UpdateRoom))]
        public ActionResult<RoomResponseModel> UpdateRoom(Guid id, RoomInputModel model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id can't be empty");
            }

            if (model == null)
            {
                return BadRequest("Model is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRoom = _roomRepository.Get(id);
            if (existingRoom == null)
                return NotFound();

            // Update the existing room entity with data from the input model
            _mapper.Map(model, existingRoom);

            var updatedRoom = _roomRepository.Update(existingRoom);

            var responseModel = _mapper.Map<RoomResponseModel>(updatedRoom);

            return Ok(responseModel);
        }


        [HttpDelete(nameof(DeleteRoom))]
        public ActionResult DeleteRoom(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id can't be empty");
            }

            var existingRoom = _roomRepository.Get(id);
            if (existingRoom == null)
                return NotFound();

            _roomRepository.Delete(existingRoom);
            return NoContent();
        }

        [HttpGet("GetRoomsByHotel/{hotelId}")]
        public ActionResult<List<RoomResponseModel>> GetRoomsByHotel(Guid hotelId)
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

            var responseModels = _mapper.Map<List<RoomResponseModel>>(rooms);
            return Ok(responseModels);
        }
    }
}
