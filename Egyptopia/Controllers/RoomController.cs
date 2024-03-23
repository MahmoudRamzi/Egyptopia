using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet(nameof(GetAllRooms))]
        public ActionResult<Room?> GetAllRooms()
        {
            return Ok(_roomRepository.GetAll());
        }

        [HttpGet(nameof(GetRoom))]
        public ActionResult<Room?> GetRoom(Guid id)
        {
            return Ok(_roomRepository.Get(id));
        }

        [HttpPost(nameof(CreateRoom))]
        public ActionResult<Room?> CreateRoom(Room room)
        {
            var data = _roomRepository.Create(room);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPut(nameof(UpdateRoom))]
        public ActionResult<Room?> UpdateRoom(Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }
            return Ok(_roomRepository.Update(room));
        }

        [HttpDelete(nameof(DeleteRoom))]
        public ActionResult DeleteRoom(Guid id)
        {
            var entity = _roomRepository.Get(id);
            if (entity == null)
                return NotFound();
            _roomRepository.Delete(entity);
            return Ok();
        }
    }
}