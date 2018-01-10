using System.Threading.Tasks;
using databasePractice.Data;
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

        public UserController(DataContext context, IUserRepository repo)
        {
            _context = context;
            _repo = repo;
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