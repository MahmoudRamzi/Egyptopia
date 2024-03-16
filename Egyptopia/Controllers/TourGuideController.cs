using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourGuideController : ControllerBase
    {
        private readonly ITourGuideRepository _tourGuideRepository;
        public TourGuideController(ITourGuideRepository tourGuideRepository)
        {
            _tourGuideRepository = tourGuideRepository;
        }
        [HttpGet(nameof(GetAllTourGuides))]
        public ActionResult<TourGuide?> GetAllTourGuides()
        {
            return Ok(_tourGuideRepository.GetAll());
        }
        [HttpGet(nameof(GetTourGuide))]
        public ActionResult<TourGuide?> GetTourGuide(Guid id)
        {
            return Ok(_tourGuideRepository.Get(id));
        }
        [HttpPost(nameof(CreateTourGuide))]
        public ActionResult<TourGuide?> CreateTourGuide(TourGuide tourGuide)
        {
            var data = _tourGuideRepository.Create(tourGuide);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }
        [HttpPut(nameof(UpdateTourGuide))]
        public ActionResult<TourGuide?> UpdateTourGuide(TourGuide tourGuide)
        {
            if (tourGuide == null)
                return BadRequest();
            return Ok(_tourGuideRepository.Update(tourGuide));
        }
        [HttpDelete(nameof(DeleteTourGuide))]
        public void DeleteTourGuide(Guid id)
        {
            _tourGuideRepository.Delete(id);
        }
    }
}
