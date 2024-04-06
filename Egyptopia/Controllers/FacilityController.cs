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
    //[ApiExplorerSettings(GroupName ="Facility")]

    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository _governorateRepository;
        private readonly IMapper _mapper;

        public FacilityController(
            IFacilityRepository governorateRepository,
            IMapper mapper)
        {
            _governorateRepository = governorateRepository;
            _mapper = mapper;
        }

        [HttpPost(nameof(CreateFacility))]
        public ActionResult<FacilityModel?> CreateFacility(FacilityModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = _governorateRepository.Create(_mapper.Map<Facility>(model));
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        //[Authorize]
        [HttpGet(nameof(GetAllFacility))]
        public ActionResult<List<FacilityModel>> GetAllFacility()
        {
            return Ok(_mapper.Map<List<FacilityModel>>(_governorateRepository.GetAll()));
        }

        [HttpGet(nameof(GetFacility))]
        public ActionResult<FacilityModel?> GetFacility(Guid id)
        {
            return Ok(_mapper.Map<FacilityModel>(_governorateRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateFacility))]
        public ActionResult<FacilityModel?> UpdateFacility(FacilityModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model == null)
                return BadRequest();
            var entity = _governorateRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_governorateRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteFacility))]
        public ActionResult DeleteFacility(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id cant be empty");
            }
            var entity = _governorateRepository.Get(id);
            if (entity == null)
                return NotFound();

            _governorateRepository.Delete(entity);
            return Ok();
        }
    }
}