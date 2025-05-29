using EnergyMonitoringWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoringWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly EnergyMonitoringDbContext _context;

        public DevicesController(EnergyMonitoringDbContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _context.Devices.ToListAsync();
            return Ok(devices);
        }

        // POST: api/Devices
        [HttpPost]
        public async Task<IActionResult> PostDevice([FromBody] Device device)
        {
            if (device == null)
                return BadRequest("Invalid device data.");

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevices), new { id = device.DeviceId }, device);
        }
    }
}
