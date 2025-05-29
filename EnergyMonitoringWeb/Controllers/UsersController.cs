using Microsoft.AspNetCore.Mvc;
using EnergyMonitoringWeb.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoringWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EnergyMonitoringDbContext _context;

        public UsersController(EnergyMonitoringDbContext context)
        {
            _context = context;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Invalid user data.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostUser), new { id = user.UserId }, user);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
