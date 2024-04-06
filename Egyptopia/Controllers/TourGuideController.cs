using AutoMapper;
using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Hotel;
using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.DTOs.TourGuide;
using Egyptopia.Domain.DTOs.TourguideComment;
using Egyptopia.Domain.DTOs.TourguideLanuage;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
using Egyptopia.Persistence.Repositories;
using EgyptopiaApi.Models;
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
    public class TourGuideController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly ITourGuideRepository _tourGuideRepository;
        private readonly IMapper _mapper;

        public TourGuideController(
            ITourGuideRepository tourGuideRepository,
            IMapper mapper,
            IImageRepository imageRepository)
        {
            _tourGuideRepository = tourGuideRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        [HttpPost(nameof(CreateTourGuide))]
        public ActionResult<Hotel> CreateTourGuide(WriteTourGuide writeTourGuide)
        {
            var tourGuide = new TourGuide
            {
                Name = writeTourGuide.Name,
                Location = writeTourGuide.Location,
                Price = writeTourGuide.Price,
                AboutInfo = writeTourGuide.AboutInfo,
                IdentityNumber = writeTourGuide.IdentityNumber, 
            };
            var data = _tourGuideRepository.Create(tourGuide);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }


        [HttpGet(nameof(GetAllTourGuide))]
        public ActionResult<List<TourGuideModell>> GetAllTourGuide()
        {
            return Ok(_mapper.Map<List<TourGuideModell>>(_tourGuideRepository.GetAll()));
        }

        [HttpGet(nameof(GetTourGuide))]
        public async Task<ActionResult<ReadTourGuide>> GetTourGuide(Guid id)
        {
            var tourGuide = await _tourGuideRepository.GetWithCommentsAndLanguages(id);
            if (tourGuide == null)
            {
                return NotFound();
            }
            var tourGuideDTo = new ReadTourGuide
            {
                Id = tourGuide.Id,
                Name = tourGuide.Name,
                Price = tourGuide.Price,
                Location = tourGuide.Location,
                AboutInfo = tourGuide.AboutInfo,
                Rate = CalculateRate((List<TourGuideComment>)tourGuide.TourGuideComments),
                Comments = tourGuide.TourGuideComments
                   .Select(c => new TourGuideCommentDTO
                   {
                       Comments = c.Comments,
                       PublishedDate = c.PublishedDate,
                       Rating = c.Rating,
                   }).ToList(),
                Languages = tourGuide.TourGuideLanguages
                    .Select(l => new TourGuideLanguageDTO
                    {
                        LanguageName = l.Language.Name
                    }).ToList(),
                TotalReviews = TotalReviews((List<TourGuideComment>)tourGuide.TourGuideComments)
            };
            var images = _imageRepository.GetAll().Where(image => image.EntityId == tourGuideDTo.Id && image.ImageEntity == ImageEntity.TourGuide)
                    .Select(h => new ImagDTO
                    {
                        Name = h.Name,
                    }).ToList();
            tourGuideDTo.Images = images;
            return Ok(tourGuideDTo);
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

        [HttpGet(nameof(GetAllWithFiltertion))]
        public async Task<ActionResult<List<ReadTourGuide>>> GetAllWithFiltertion(string? term, string? sort, int page = 1, int limit = 5)
        {
            var tourGuideResult = await _tourGuideRepository.GetAllWithFiltertion(term, sort, page, limit);
            //add pagination header to the response
            Response.Headers.Add("TourGuides-Total-Count", tourGuideResult.TotalCount.ToString());
            Response.Headers.Add("TourGuides-Total-Pages", tourGuideResult.TotalPages.ToString());
            return Ok(tourGuideResult.tourGuides);

        }

        public static int CalculateRate(List<TourGuideComment> comments)
        {
            if (comments.Count > 0)
            {
                return (comments.Sum(s => s.Rating) / comments.Count);
            }
            else
            {
                return 0;
            }
        }
        public static string TotalReviews(List<TourGuideComment> comments)
        {
            if (comments.Count > 0)
            {
                return $"{comments.Count} Reviews";
            }
            else
            {
                return "Be the first to comment.";
            }
        }
    }
}