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

    public class BookingTourGuideController : ControllerBase
    {
        private readonly IBookingTourGuideRepository _bookingTourGuidRepository;
        private readonly ITourGuideRepository _tourGuideRepository;
        private readonly IMapper _mapper;
        public BookingTourGuideController(
            IBookingTourGuideRepository bookingTourGuideRepository,
            IMapper mapper,
            ITourGuideRepository tourGuideRepository
            )
        {
            _bookingTourGuidRepository = bookingTourGuideRepository;
            _mapper = mapper;

            _tourGuideRepository = tourGuideRepository;

        }


        [HttpPost(nameof(CreateTourGuideBooking))]
        public async Task<ActionResult<BookingTourGuideResponseModel>> CreateTourGuideBooking([FromBody] BookingTourGuideInputModel inputModel)
        {
            // Check if booking exists for the same date and tour guide
            var existingBooking = await _bookingTourGuidRepository.GetExistingBooking(inputModel.CheckInDate, inputModel.TourGuideId);
            if (existingBooking != null)
            {
                return BadRequest("A booking for this date and tour guide already exists.");
            }

            // Retrieve the tour guide to get the price
            var tourGuide =  _tourGuideRepository.Get(inputModel.TourGuideId.Value);
            if (tourGuide == null)
            {
                return BadRequest("Tour guide not found.");
            }

            // Calculate the total amount
            var totalAmount = inputModel.NumberOfGuests * tourGuide.Price;

            // Map the input model to the domain entity
            var bookingEntity = _mapper.Map<BookingTourGuide>(inputModel);
            bookingEntity.TotalAmount = totalAmount; // Set the calculated total amount

            // Save the new booking
            var createdBooking = _bookingTourGuidRepository.Create(bookingEntity);
            if (createdBooking == null)
            {
                return BadRequest("Unable to create booking.");
            }

            // Map the domain entity to the response model
            var responseModel = _mapper.Map<BookingTourGuideResponseModel>(createdBooking);

            // Return the created booking with the route to get it
            return CreatedAtAction(nameof(GetTourGuideBooking), new { id = responseModel.Id }, responseModel);
        }

        //[Authorize]
        [HttpGet(nameof(GetAllTourGuideBooking))]
        public ActionResult<List<BookingTourGuideResponseModel>> GetAllTourGuideBooking()
        {
            return Ok(_mapper.Map<List<BookingTourGuide>>(_bookingTourGuidRepository.GetAll()));
        }

        [HttpGet(nameof(GetTourGuideBooking))]
        public ActionResult<BookingTourGuideResponseModel?> GetTourGuideBooking(Guid id)
        {
            return Ok(_mapper.Map<BookingTourGuide>(_bookingTourGuidRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateTourGuideBooking))]
        public ActionResult<BookingTourGuideInputModel?> UpdateTourGuideBooking(BookingTourGuideResponseModel model)
        {
            if (model == null)
                return BadRequest();
            var entity = _bookingTourGuidRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_bookingTourGuidRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteTourGuideBooking))]
        public ActionResult DeleteTourGuideBooking(Guid id)
        {
            var entity = _bookingTourGuidRepository.Get(id);
            if (entity == null)
                return NotFound();

            _bookingTourGuidRepository.Delete(entity);
            return Ok();
        }
        [HttpGet("GetBookingsForTourGuide/{tourGuideId}")]
        public async Task<ActionResult<IEnumerable<BookingTourGuideResponseModel>>> GetBookingsForTourGuide(Guid tourGuideId)
        {
            // Retrieve all bookings for the specified tour guide
            var bookings = await _bookingTourGuidRepository.GetBookingsByTourGuideId(tourGuideId);
            if (bookings == null || !bookings.Any())
            {
                return NotFound("No bookings found for this tour guide.");
            }

            // Map the bookings to the response model
            var responseModels = _mapper.Map<IEnumerable<BookingTourGuideResponseModel>>(bookings);

            return Ok(responseModels);
        }


    }
}