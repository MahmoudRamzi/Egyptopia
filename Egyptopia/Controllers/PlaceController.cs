using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet(nameof(GetAllPlaces))]
        public ActionResult<Place?> GetAllPlaces()
        {
            return Ok(_placeRepository.GetAll());
        }

        [HttpGet(nameof(GetPlace))]
        public ActionResult<Place?> GetPlace(Guid id)
        {
            return Ok(_placeRepository.Get(id));
        }

        [HttpPost(nameof(CreatePlace))]
        public ActionResult<Place?> CreatePlace(Place place)
        {
            var data = _placeRepository.Create(place);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPut(nameof(UpdatePlace))]
        public ActionResult<Place?> UpdatePlace(Place place)
        {
            if (place == null)
                return BadRequest();
            return Ok(_placeRepository.Update(place));
        }

        [HttpDelete(nameof(DeletePlace))]
        public void DeletePlace(Guid id)
        {
            _placeRepository.Delete(id);
        }
    }
}