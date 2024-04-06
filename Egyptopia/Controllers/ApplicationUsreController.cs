using Egyptopia.Application.Repositories;
using Egyptopia.Domain.DTOs.Authentication;
using Egyptopia.Domain.DTOs.Image;
using Egyptopia.Domain.DTOs.Token;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EgyptopiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsreController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUsreController(IConfiguration configuration, UserManager<ApplicationUser> userManager,IImageRepository imageRepository) 
        {
            _configuration = configuration;
            _userManager = userManager;
            _imageRepository = imageRepository;
        }
        [HttpPost]
        [Route("StaticLogin")]
        public ActionResult<string> StaticLogin(LoginDTO credentials)
        {
            if (credentials.Email == "Admin@gmail.com" && credentials.Password == "Mhaa12456789@")
            {
                var UserClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, credentials.Email),
                    new Claim(ClaimTypes.NameIdentifier ,credentials.Email),
                    new Claim("Nationality","Egyptian"),
                    new Claim("sub","Admin")
                };
                //Generate key
                var secretkey = _configuration.GetValue<string>("secretkey");
                var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
                var key = new SymmetricSecurityKey(secretkeyinbytes);
                //how to hash
                var methodusedforGeneratingToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                //generate token
                var jwt = new JwtSecurityToken(
                    claims: UserClaims,
                    notBefore: DateTime.Now,
                    issuer: "backenapp",
                    audience:"hotel",
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: methodusedforGeneratingToken);
                var tokenHandeler = new JwtSecurityTokenHandler();
                var tokenString = tokenHandeler.WriteToken(jwt);
                return Ok( tokenString );
            }
            return Unauthorized("Wrong Email Or Password"); 
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var IsLocked = await _userManager.IsLockedOutAsync(user);
            if (IsLocked)
            {
                return BadRequest("Try again");
            }
            var IsAuthenticatd = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!IsAuthenticatd)
            {
                await _userManager.AccessFailedAsync(user);
                return Unauthorized("Wrong credentials");
            }

            var UserClaims = await _userManager.GetClaimsAsync(user);
            //Generate key
            var secretkey = _configuration.GetValue<string>("secretkey");
            var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
            var key = new SymmetricSecurityKey(secretkeyinbytes);
            //how to hash
            var methodusedforGeneratingToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            //generate token
            var Exp = DateTime.Now.AddMinutes(15);
            var jwt = new JwtSecurityToken(
                claims: UserClaims,
                notBefore: DateTime.Now,
                issuer: "backenapp",
                audience: "hotel",
                expires: Exp,
                signingCredentials: methodusedforGeneratingToken);
            var tokenHandeler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandeler.WriteToken(jwt);

            var Token = new TokenDTO
            {
                Token = tokenString,
                ExpiryDate = Exp,
            };
            return Token;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<string>> Register(RegisterDTO registerDTO)
        {
            var NewUser = new ApplicationUser
            {
                UserName = $"{registerDTO.FirstName}_{registerDTO.LastName}{registerDTO.DOB.Day}{registerDTO.DOB.Month}{registerDTO.DOB.Year}",
                Email = registerDTO.Email,
                Country = registerDTO.Country,
                DOB = registerDTO.DOB,
                PhoneNumber = registerDTO.PhoneNumber,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                
            };
            var CreationResult = await _userManager.CreateAsync(NewUser,registerDTO.Password);
            if ( !CreationResult.Succeeded )
            {
                return BadRequest(CreationResult.Errors);
            }
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(registerDTO.DOB.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
            var images = _imageRepository.GetAll().Where(image => image.EntityId == NewUser.Id && image.ImageEntity == ImageEntity.User)
                    .Select(h => new ImagDTO
                    {
                        Name = h.Name,
                    }).ToList();
            var imageName = images.Count > 0 ? images[0].Name : string.Empty;
            var UserClaims = new List<Claim>
                {
                    new Claim("Email", NewUser.Email),
                    new Claim("User Name" ,$"{registerDTO.FirstName} {registerDTO.LastName}"),
                    new Claim("MobilePhone", registerDTO.PhoneNumber),
                    new Claim("Country",registerDTO.Country),
                    new Claim("Role", registerDTO.Role),
                    new Claim("age",$"{age}"),
                    new Claim("Id",$"{NewUser.Id}"),
                    new Claim("ImageName",imageName)
                };
            await _userManager.AddClaimsAsync(NewUser, UserClaims);

            return Ok( CreationResult );
        }
    }
}
