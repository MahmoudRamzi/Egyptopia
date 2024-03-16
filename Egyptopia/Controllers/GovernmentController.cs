﻿using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
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
            var data = _governorateRepository.Create(governorate);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
        [HttpGet(nameof(GetAllGovernorate))]
        public ActionResult<Governorate?> GetAllGovernorate()
        {
            return Ok(_governorateRepository.GetAll());
        }
        [HttpGet(nameof(GetGovernorate))]
        public ActionResult<Governorate?> GetGovernorate(Guid id)
        {
            return Ok(_governorateRepository.Get(id));
        }
        [HttpPut(nameof(UpdateGovernorate))]
        public ActionResult<Governorate?> UpdateGovernorate(Governorate governorate)
        {
            if (governorate == null)
                return BadRequest();
            return Ok(_governorateRepository.Update(governorate));
        }
        [HttpDelete(nameof(DeleteGovernorate))]
        public void DeleteGovernorate(Guid id)
        {
            _governorateRepository.Delete(id);
        }
    }
}
