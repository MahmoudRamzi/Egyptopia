using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.DTOs.HotelComment;
using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelCommentController : ControllerBase
    {
        private readonly IHotelCommentRepository _hotelCommentRepository;
        public HotelCommentController(IHotelCommentRepository hotelCommentRepository) 
        {
            _hotelCommentRepository = hotelCommentRepository;
        }
        [HttpPost(nameof(CreateHotelComment))]
        public ActionResult<HotelComment> CreateHotelComment(WriteHotelComment writeHotelComment)
        {
            var hotelComment = new HotelComment
            {
                Rating = writeHotelComment.Rating,
                Comments = writeHotelComment.Comments,
                PublishedDate = writeHotelComment.PublishedDate,
                ApplicationUserId = writeHotelComment.ApplicationUserId,
                HotelId = writeHotelComment.HotelId
            };
            var data = _hotelCommentRepository.Create(hotelComment);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
