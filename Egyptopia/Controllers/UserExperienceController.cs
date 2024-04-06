using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.DTOs.TourGuide;
using Egyptopia.Domain.DTOs.Userexperience;
using Egyptopia.Domain.Enums;
using EgyptopiaApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Egyptopia.Domain.Entities;


namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExperienceController : ControllerBase
    {
        private readonly IUserExperienceRepository _userExperienceRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public UserExperienceController( IUserExperienceRepository userExperienceRepository, IImageRepository imageRepository,IWebHostEnvironment webHostEnvironment,IMapper mapper)
        {
            _userExperienceRepository = userExperienceRepository;
            _imageRepository = imageRepository;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;

        }
        [HttpGet(nameof(GetAllUserExperiences))]
        public ActionResult<List<ReadUserExperience>> GetAllUserExperiences()
        {
            
            var userExperiences = _userExperienceRepository.GetAllWithUser();
            if (userExperiences == null)
            {
                return NotFound();
            }
            var userExperiencesDto = userExperiences
                .Select(u => new ReadUserExperience
                {
                    Description = u.Description,
                    ApplicationUserId = u.ApplicationUserId,
                }).ToList();
            
            for (int i = 0; i < userExperiencesDto.Count; i++)
            {
                var images = _imageRepository.GetAll().Where(image => image.EntityId == userExperiencesDto[i].ApplicationUserId && image.ImageEntity == ImageEntity.UserEperience)
                    .Select(h => new ImagDTO
                    {
                        Name = h.Name,
                    }).ToList();
                var imageName = images.Count > 0 ? images[0].Name : string.Empty;
                userExperiencesDto[i].ExperinceImageName = imageName;
            }
            for (int i = 0; i < userExperiencesDto.Count; i++)
            {
                var images = _imageRepository.GetAll().Where(image => image.EntityId == userExperiencesDto[i].ApplicationUserId && image.ImageEntity == ImageEntity.User)
                    .Select(h => new ImagDTO
                    {
                        Name = h.Name,
                    }).ToList();
                var imageName = images.Count > 0 ? images[0].Name : string.Empty;
                userExperiencesDto[i].PersonalImageName = imageName;
            }

            return Ok(userExperiencesDto);
        }

        [HttpPost(nameof(CreateUserExperience))]
        public async Task<ActionResult<ImageModel?>> CreateUserExperience([FromForm] WriteUserExperience userExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = new ImageModel
            {
                File = userExperience.File,
                EntityId = userExperience.ApplicationUserId,
                ImageEntity = ImageEntity.UserEperience,
            };
            var imageName = await SaveImage(model.File);

            var imageEntity = _mapper.Map<Image>(model);
            imageEntity.Name = imageName;
            var data = _imageRepository.Create(imageEntity);
            if (data == null)
            {
                return BadRequest("Can't Uplaod Image");
            }
            var experience = new UserExprience
            {
                Description = userExperience.Description,
                ApplicationUserId = userExperience.ApplicationUserId,
            };
            var createUserExperience = _userExperienceRepository.Create(experience);
            if (createUserExperience == null)
            {
                return BadRequest("Can't Create This Experience");
            }
            return Ok(createUserExperience);
        }

        private async Task<string> SaveImage(IFormFile file)
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

                    return uniqueFileName;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
