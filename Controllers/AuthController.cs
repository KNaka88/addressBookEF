using System;
using System.Threading.Tasks;
using AutoMapper;
using databasePractice.Data;
using databasePractice.Dtos;
using databasePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace databasePractice.Controllers
{

    [Route("api/[controller]")]
    public class AuthController: Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper) 
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if (!string.IsNullOrEmpty(userForRegisterDto.Email))
                userForRegisterDto.Email = userForRegisterDto.Email.ToLower();
            
            if (await _repo.IsUserExist(userForRegisterDto.Email))
                ModelState.AddModelError("Email", "Email is already used in another account");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userToCreate = _mapper.Map<User>(userForRegisterDto);
            
            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            
            var userToReturn = _mapper.Map<UserForDetailDto>(createdUser);

            return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.Id}, userToReturn);
        }  

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var user = await _repo.Login(userForLoginDto.Email, userForLoginDto.Password);

            if (user == null)
                return Unauthorized();
            
            //TODO ADD JWTtoken

            return Ok();
        }      
    }
}