using Egyptopia.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet(nameof(GetAllImages))]
        public ActionResult<Egyptopia.Domain.Entities.Image?> GetAllImages()
        {
            return Ok(_imageRepository.GetAll());
        }

        [HttpGet(nameof(GetImage))]
        public ActionResult<Egyptopia.Domain.Entities.Image?> GetImage(Guid id)
        {
            return Ok(_imageRepository.Get(id));
        }

        [HttpPost(nameof(CreateImage))]
        public ActionResult<Egyptopia.Domain.Entities.Image?> CreateImage(Egyptopia.Domain.Entities.Image image)
        {
            var data = _imageRepository.Create(image);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPut(nameof(UpdateImage))]
        public ActionResult<Egyptopia.Domain.Entities.Image?> UpdateImage(Egyptopia.Domain.Entities.Image image)
        {
            if (image == null)
                return BadRequest();
            return Ok(_imageRepository.Update(image));
        }

        [HttpDelete(nameof(DeleteImage))]
        public void DeleteImage(Guid id)
        {
            _imageRepository.Delete(id);
        }
    }
}