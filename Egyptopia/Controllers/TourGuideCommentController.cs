using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.HotelComment;
using Egyptopia.Domain.DTOs.TourguideComment;
using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourGuideCommentController : ControllerBase
    {
        private readonly ITourGuideCommentRepository _tourGuideCommentRepository;
        public TourGuideCommentController(ITourGuideCommentRepository tourGuideCommentRepository)
        {
            _tourGuideCommentRepository = tourGuideCommentRepository;
        }
        [HttpPost(nameof(CreateTourGuideComment))]
        public ActionResult<TourGuideComment> CreateTourGuideComment(WriteTourGuideComment writeTourGuideComment)
        {
            var tourGuideComment = new TourGuideComment
            {
                Rating = writeTourGuideComment.Rating,
                Comments = writeTourGuideComment.Comments,
                PublishedDate = writeTourGuideComment.PublishedDate,
                ApplicationUserId = writeTourGuideComment.ApplicationUserId,
                TourGuideId = writeTourGuideComment.TourGuideId
            };
            var data = _tourGuideCommentRepository.Create(tourGuideComment);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
