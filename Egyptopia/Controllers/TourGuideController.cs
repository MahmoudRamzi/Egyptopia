using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourGuideController : ControllerBase
    {
        private readonly ITourGuideRepository _tourGuideRepository;
        private readonly IMapper _mapper;

        public TourGuideController(
            ITourGuideRepository tourGuideRepository,
            IMapper mapper)
        {
            _tourGuideRepository = tourGuideRepository;
            _mapper = mapper;
        }

        [HttpPost(nameof(CreateTourGuide))]
        public ActionResult<TourGuideModel?> CreateTourGuide(TourGuideModel model)
        {
            var data = _tourGuideRepository.Create(_mapper.Map<TourGuide>(model));
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [Authorize]
        [HttpGet(nameof(GetAllTourGuide))]
        public ActionResult<List<TourGuideModel>> GetAllTourGuide()
        {
            return Ok(_mapper.Map<List<TourGuideModel>>(_tourGuideRepository.GetAll()));
        }

        [HttpGet(nameof(GetTourGuide))]
        public ActionResult<TourGuideModel?> GetTourGuide(Guid id)
        {
            return Ok(_mapper.Map<TourGuideModel>(_tourGuideRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateTourGuide))]
        public ActionResult<TourGuideModel?> UpdateTourGuide(TourGuideModel model)
        {
            if (model == null)
                return BadRequest();
            var entity = _tourGuideRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_tourGuideRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteTourGuide))]
        public ActionResult DeleteTourGuide(Guid id)
        {
            var entity = _tourGuideRepository.Get(id);
            if (entity == null)
                return NotFound();

            _tourGuideRepository.Delete(entity);
            return Ok();
        }
    }
}