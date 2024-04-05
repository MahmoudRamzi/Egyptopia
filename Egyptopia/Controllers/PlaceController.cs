using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.DTOs.Place;
using Egyptopia.Domain.DTOs.TourGuide;
using Egyptopia.Domain.DTOs.TourguideComment;
using Egyptopia.Domain.DTOs.TourguideLanuage;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
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
        private readonly IImageRepository _imageRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public PlaceController(
            IPlaceRepository placeRepository,
            IMapper mapper,
            IImageRepository imageRepository)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        [HttpPost(nameof(CreatePlace))]
        public ActionResult<PlaceInputModel> CreatePlace(PlaceInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var place = new Place
            {
                Description = model.Description,
                Location = model.Location,
                Name = model.Name,
                GovernorateId = model.GovernorateId,
                PlaceType = model.PlaceType,
            };
            var data = _placeRepository.Create(place);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [Authorize]
        [HttpGet(nameof(GetAllPlace))]
        public ActionResult<List<PlaceResponseModel>> GetAllPlace()
        {
            var places =  _placeRepository.GetAllWithGovernorate();
            if (places == null)
            {
                return NotFound();
            }
            var placesDto = _placeRepository.Mapping(places);

            return Ok(placesDto);
        }

        [HttpGet(nameof(GetPlace))]
        public ActionResult<PlaceResponseModel> GetPlace(Guid id)
        {
            var place = _placeRepository.Get(id);
            if (place == null)
            {
                return NotFound();
            }
            var placeDTo = new PlaceResponseModel
            {
                Id = place.Id,
                Name = place.Name,
                Location = place.Location,
                Description = place.Description,
                GovernorateId = place.GovernorateId,
                GovernorateName = place.Governorate.Name
            };
            var images = _imageRepository.GetAll().Where(image => image.EntityId == placeDTo.Id && image.ImageEntity == ImageEntity.Place)
                    .Select(h => new ImagDTO
                    {
                        Name = h.Name,
                    }).ToList();
            placeDTo.Images = images;
            return Ok(placeDTo);
        }

        [HttpPut(nameof(UpdatePlace))]
        public ActionResult<PlaceInputModel> UpdatePlace(PlaceResponseModel model)
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
        public async Task<ActionResult<List<PlaceResponseModel>>> GetPlacesByType(PlaceType type)
        {
            var places = await _placeRepository.GetAllPlacesDetailsByType(type);
            if (places == null)
            {
                return NotFound();
            }
            var placesDto = _placeRepository.Mapping(places);

            return Ok(placesDto);
        }

    }
}