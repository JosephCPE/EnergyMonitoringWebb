using EnergyMonitoringWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EnergyMonitoringWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyDataController : ControllerBase
    {
        private readonly EnergyMonitoringDbContext _context;

        public EnergyDataController(EnergyMonitoringDbContext context)
        {
            _context = context;
        }

        // GET: api/EnergyData
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.EnergyData.ToListAsync();
            return Ok(data);
        }

        // POST: api/EnergyData
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnergyData energyData)
        {
            if (energyData == null)
                return BadRequest("Invalid data.");

            // Validate DeviceId foreign key
            var deviceExists = await _context.Devices.AnyAsync(d => d.DeviceId == energyData.DeviceId);
            if (!deviceExists)
                return BadRequest($"Device with ID {energyData.DeviceId} does not exist.");

            // Set timestamp if default or null
            if (energyData.Timestamp == null || energyData.Timestamp == default)
                energyData.Timestamp = DateTime.Now;

            _context.EnergyData.Add(energyData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = energyData.DataId }, energyData);
        }
    }
}
