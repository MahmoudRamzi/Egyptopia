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
        private readonly IBookingRepository _bookingRoomRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public BookingRoomController(
            IBookingRepository bookingRepository,
            IMapper mapper,
            IRoomRepository roomRepository
            )
        {
            _bookingRoomRepository = bookingRepository;
            _mapper = mapper;

            _roomRepository = roomRepository;

        }

        [HttpPost(nameof(CreateBooking))]
        public ActionResult<BookingModel?> CreateBooking(BookingModel model)
        {
            var data = _bookingRoomRepository.Create(_mapper.Map<Booking>(model));
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [Authorize]
        [HttpGet(nameof(GetAllBooking))]
        public ActionResult<List<BookingModel>> GetAllBooking()
        {
            return Ok(_mapper.Map<List<BookingModel>>(_bookingRoomRepository.GetAll()));
        }

        [HttpGet(nameof(GetBooking))]
        public ActionResult<BookingModel?> GetBooking(Guid id)
        {
            return Ok(_mapper.Map<BookingModel>(_bookingRoomRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateBooking))]
        public ActionResult<BookingModel?> UpdateBooking(BookingModel model)
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
        public async Task<ActionResult<BookingModel?>> CreateRoomBooking(BookingModel model)
        {
            var room = _roomRepository.Get(model.RoomId.GetValueOrDefault());
            var roomNumber = await _bookingRoomRepository.GetRemainingRooms(room.HotelId, room.RoomType, model.CheckInDate, model.CheckOutDate);
            if (!roomNumber.Any())
            {
                return BadRequest("no empty room");
            }
            model.RoomNumber = roomNumber.FirstOrDefault();
            var data = _bookingRoomRepository.Create(_mapper.Map<Booking>(model));

            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

    }
}