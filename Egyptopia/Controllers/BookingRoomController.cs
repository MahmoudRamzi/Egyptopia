using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //to be modified

    public class BookingRoomController : ControllerBase
    {
        private readonly IBookingRoomRepository _bookingRoomRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public BookingRoomController(
            IBookingRoomRepository bookingRoomRepository,
            IMapper mapper,
            IRoomRepository roomRepository
            )
        {
            _bookingRoomRepository = bookingRoomRepository;
            _mapper = mapper;

            _roomRepository = roomRepository;

        }

        

        //[Authorize]
        [HttpGet(nameof(GetAllBooking))]
        public ActionResult<List<BookingRoomResponseModel>> GetAllBooking()
        {
            return Ok(_mapper.Map<List<BookingRoom>>(_bookingRoomRepository.GetAll()));
        }

        [HttpGet(nameof(GetBooking))]
        public ActionResult<BookingTourGuideResponseModel?> GetBooking(Guid id)
        {
            return Ok(_mapper.Map<BookingRoom>(_bookingRoomRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateBooking))]
        public ActionResult<BookingRoomInputModel?> UpdateBooking(BookingRoomResponseModel model)
        {
            if (model == null)
                return BadRequest();
            var entity = _bookingRoomRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_bookingRoomRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteBooking))]
        public ActionResult DeleteBooking(Guid id)
        {
            var entity = _bookingRoomRepository.Get(id);
            if (entity == null)
                return NotFound();

            _bookingRoomRepository.Delete(entity);
            return Ok();
        }
        [HttpGet(nameof(GetRemainingRooms))]
        public async Task<ActionResult<List<int>>> GetRemainingRooms(Guid hotelId, string roomType, DateTime checkInDate, DateTime checkOutDate)
        {
            return Ok(await _bookingRoomRepository.GetRemainingRooms(hotelId, roomType, checkInDate, checkOutDate));
        }
        [HttpPost(nameof(CreateRoomBooking))]
        public async Task<ActionResult<BookingRoomResponseModel?>> CreateRoomBooking(BookingRoomInputModel model)
        {
            var room = _roomRepository.Get(model.RoomId.GetValueOrDefault());
            var roomNumber = await _bookingRoomRepository.GetRemainingRooms(room.HotelId, room.RoomType, model.CheckInDate, model.CheckOutDate);
            if (!roomNumber.Any())
            {
                return BadRequest("no empty room");
            }
            model.RoomNumber = roomNumber.FirstOrDefault();
            var data = _bookingRoomRepository.Create(_mapper.Map<BookingRoom>(model));

            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }


    }
}