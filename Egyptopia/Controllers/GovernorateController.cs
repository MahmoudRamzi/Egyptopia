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
    //[ApiExplorerSettings(GroupName ="Governorate")]
    
    public class GovernorateController : ControllerBase
    {
        private readonly IGovernorateRepository _governorateRepository;
        private readonly IMapper _mapper;

        public GovernorateController(
            IGovernorateRepository governorateRepository,
            IMapper mapper)
        {
            _governorateRepository = governorateRepository;
            _mapper = mapper;
        }

        [HttpPost(nameof(CreateGovernorate))]
        public ActionResult<GovernorateModel?> CreateGovernorate(GovernorateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = _governorateRepository.Create(_mapper.Map<Governorate>(model));
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [Authorize]
        [HttpGet(nameof(GetAllGovernorate))]
        public ActionResult<List<GovernorateModel>> GetAllGovernorate()
        {
            return Ok(_mapper.Map<List<GovernorateModel>>(_governorateRepository.GetAll()));
        }

        [HttpGet(nameof(GetGovernorate))]
        public ActionResult<GovernorateModel?> GetGovernorate(Guid id)
        {
            return Ok(_mapper.Map<GovernorateModel>(_governorateRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateGovernorate))]
        public ActionResult<GovernorateModel?> UpdateGovernorate(GovernorateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model == null)
                return BadRequest();
            var entity = _governorateRepository.Get(model.Id);
            if(entity == null)            
                return NotFound();            
            return Ok(_governorateRepository.Update(_mapper.Map(model,entity)));
        }

        [HttpDelete(nameof(DeleteGovernorate))]
        public ActionResult DeleteGovernorate(Guid id)
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