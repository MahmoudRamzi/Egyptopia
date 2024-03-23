using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using EgyptopiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(
            IImageRepository imageRepository,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost(nameof(CreateImage))]
        public ActionResult<ImageModel?> CreateImage([FromForm]ImageModel model)
        {
            var data = _imageRepository.Create(_mapper.Map<Image>(model));
            if (data == null)
            {
                return BadRequest();
            }
            SaveImage(model.File);
            return Ok(data);
        }


        [Authorize]
        [HttpGet(nameof(GetAllImage))]
        public ActionResult<List<ImageModel>> GetAllImage()
        {
            return Ok(_mapper.Map<List<ImageModel>>(_imageRepository.GetAll()));
        }

        [HttpGet(nameof(GetImage))]
        public ActionResult<ImageModel?> GetImage(Guid id)
        {
            return Ok(_mapper.Map<ImageModel>(_imageRepository.Get(id)));
        }

        [HttpPut(nameof(UpdateImage))]
        public ActionResult<ImageModel?> UpdateImage(ImageModel model)
        {
            if (model == null)
                return BadRequest();
            var entity = _imageRepository.Get(model.Id);
            if (entity == null)
                return NotFound();
            SaveImage(model.File);
            return Ok(_imageRepository.Update(_mapper.Map(model, entity)));
        }

        [HttpDelete(nameof(DeleteImage))]
        public ActionResult DeleteImage(Guid id)
        {
            var entity = _imageRepository.Get(id);
            if (entity == null)
                return NotFound();

            _imageRepository.Delete(entity);
            return Ok();
        }

        private async Task<bool> SaveImage(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}