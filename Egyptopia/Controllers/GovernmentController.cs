using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentController : ControllerBase
    {
        private readonly IGovernorateRepository _governorateRepository;

        public GovernmentController(IGovernorateRepository governorateRepository)
        {
            _governorateRepository = governorateRepository;
        }

        [HttpPost(nameof(CreateGovernorate))]
        public ActionResult<Governorate?> CreateGovernorate(Governorate governorate)
        {
            var data=_governorateRepository.Create(governorate);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        [HttpGet(nameof(GetListGovernorate))]
        public ActionResult<Governorate?> GetListGovernorate()
        {            
            return Ok(_governorateRepository.GetAll());
        }
    }
}
