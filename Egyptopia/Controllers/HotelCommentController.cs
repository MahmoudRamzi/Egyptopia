using Egyptopia.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
