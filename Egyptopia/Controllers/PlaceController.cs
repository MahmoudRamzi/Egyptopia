using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
using EgyptopiaApi.Models.Place;
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
    //[ApiExplorerSettings(GroupName ="Place")]

    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public PlaceController(
            IPlaceRepository placeRepository,
            IMapper mapper)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
        }

        [HttpPost(nameof(CreatePlace))]
        public ActionResult<PlaceResponseModel?> CreatePlace(PlaceResponseModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = _placeRepository.Create(_mapper.Map<Place>(model));
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [Authorize]
        [HttpGet(nameof(GetAllPlace))]
        public ActionResult<List<PlaceInputModel>> GetAllPlace()
        {
            return Ok(_mapper.Map<List<PlaceInputModel>>(_placeRepository.GetAll()));
        }

        [HttpGet(nameof(GetPlace))]
        public ActionResult<PlaceInputModel?> GetPlace(Guid id)
        {
            return Ok(_mapper.Map<PlaceInputModel>(_placeRepository.Get(id)));
        }

        [HttpPut(nameof(UpdatePlace))]
        public ActionResult<PlaceResponseModel> UpdatePlace(PlaceInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model == null)
                return BadRequest();
            var entity = _placeRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            return Ok(_placeRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeletePlace))]
        public ActionResult DeletePlace(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id cant be empty");
            }
            var entity = _placeRepository.Get(id);
            if (entity == null)
                return NotFound();

            _placeRepository.Delete(entity);
            return Ok();
        }
        [HttpGet("GetPlacesByType")]
        public async Task<ActionResult<IEnumerable<PlaceInputModel>>> GetPlacesByType(PlaceType type)
        {
            var places = await _placeRepository.GetAllPlacesDetailsByType(type);
            return Ok(_mapper.Map<IEnumerable<PlaceInputModel>>(places));
        }

    }
}