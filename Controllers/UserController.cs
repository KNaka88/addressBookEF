using System.Threading.Tasks;
using AutoMapper;
using databasePractice.Data;
using databasePractice.Dtos;
using databasePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace databasePractice.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly DataContext _context;
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(DataContext context, IUserRepository repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserForUpdateDto userForUpdateDto)
        {
            var user = await _repo.GetUser(id);

            if (user == null)
                return NotFound("Could not find user");

            _mapper.Map(userForUpdateDto, user);

            if (await _repo.SaveAll())
                return Ok();
    
            throw new AutoMapperConfigurationException($"Updating user {id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repo.GetUser(id);

            if (user == null)
                return NotFound();
            
            _repo.Delete(user);

            if (await _repo.SaveAll())
                return Ok();
            else
                return BadRequest("Failed to delete user");
        }
    }
}