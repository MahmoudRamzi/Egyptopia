using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourGuideServiceController : ControllerBase
    {
        private readonly ITourGuideServiceRepository _tourGuideServiceRepository;

        public TourGuideServiceController(ITourGuideServiceRepository tourGuideServiceRepository)
        {
            _tourGuideServiceRepository = tourGuideServiceRepository;
        }

        [HttpGet(nameof(GetAllTourGuideServices))]
        public ActionResult<TourGuideService?> GetAllTourGuideServices()
        {
            return Ok(_tourGuideServiceRepository.GetAll());
        }

        [HttpGet(nameof(GetTourGuideService))]
        public ActionResult<TourGuideService?> GetTourGuideService(Guid id)
        {
            return Ok(_tourGuideServiceRepository.Get(id));
        }

        [HttpPost(nameof(CreateTourGuideService))]
        public ActionResult<TourGuideService?> CreateTourGuideService(TourGuideService tourGuideService)
        {
            var data = _tourGuideServiceRepository.Create(tourGuideService);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        [HttpPut(nameof(UpdateTourGuideService))]
        public ActionResult<TourGuide?> UpdateTourGuideService(TourGuideService tourGuideService)
        {
            if (tourGuideService == null)
                return BadRequest();
            return Ok(_tourGuideServiceRepository.Update(tourGuideService));
        }

        [HttpDelete(nameof(DeleteTourGuideService))]
        public void DeleteTourGuideService(Guid id)
        {
            _tourGuideServiceRepository.Delete(id);
        }
    }
}