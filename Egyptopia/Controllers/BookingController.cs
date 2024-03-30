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

    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public BookingController(
            IBookingRepository bookingRepository,
            IMapper mapper,
            IRoomRepository roomRepository
            )
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            
            _roomRepository = roomRepository;

        }

        [HttpPost(nameof(CreateBooking))]
        public ActionResult<BookingModel?> CreateBooking(BookingModel model)
        {
            var data = _bookingRepository.Create(_mapper.Map<Booking>(model));
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
            return Ok(_mapper.Map<List<BookingModel>>(_bookingRepository.GetAll()));
        }

        [HttpGet(nameof(GetBooking))]
        public ActionResult<BookingModel?> GetBooking(Guid id)
        {
            return Ok(_mapper.Map<BookingModel>(_bookingRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateBooking))]
        public ActionResult<BookingModel?> UpdateBooking(BookingModel model)
        {
            if (model == null)
                return BadRequest();
            var entity = _bookingRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_bookingRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteBooking))]
        public ActionResult DeleteBooking(Guid id)
        {
            var entity = _bookingRepository.Get(id);
            if (entity == null)
                return NotFound();

            _bookingRepository.Delete(entity);
            return Ok();
        }
        [HttpGet(nameof(GetRemainingRooms))]
        public async Task <ActionResult<List<int>>> GetRemainingRooms(Guid hotelId,string roomType , DateTime checkInDate,DateTime checkOutDate)
        {
            return Ok(await _bookingRepository.GetRemainingRooms(hotelId,roomType,checkInDate,checkOutDate));
        }
        [HttpPost(nameof(CreateRoomBooking))]
        public async Task <ActionResult<BookingModel?>> CreateRoomBooking(BookingModel model)
        {
            var room=_roomRepository.Get(model.RoomId.GetValueOrDefault());
            var roomNumber =await _bookingRepository.GetRemainingRooms(room.HotelId.GetValueOrDefault(),room.RoomType,model.CheckInDate,model.CheckOutDate);
            if (!roomNumber.Any())
            {
                return BadRequest("no empty room");
            }
            model.RoomNumber = roomNumber.FirstOrDefault();
            var data = _bookingRepository.Create(_mapper.Map<Booking>(model));

            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

    }
}