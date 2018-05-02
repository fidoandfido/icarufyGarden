using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IcarufyGarden.Data;
using IcarufyGarden.Models.Entities;

namespace IcarufyGarden.Controllers
{
    [Produces("application/json")]
    [Route("api/GardenTasks")]
    public class GardenTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GardenTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GardenTasks
        [HttpGet]
        public IEnumerable<GardenTask> GetGardenTask()
        {
            return _context.GardenTask;
        }

        // GET: api/GardenTasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGardenTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gardenTask = await _context.GardenTask.SingleOrDefaultAsync(m => m.Id == id);

            if (gardenTask == null)
            {
                return NotFound();
            }

            return Ok(gardenTask);
        }

        // PUT: api/GardenTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGardenTask([FromRoute] int id, [FromBody] GardenTask gardenTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gardenTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(gardenTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GardenTasks
        [HttpPost]
        public async Task<IActionResult> PostGardenTask([FromBody] GardenTask gardenTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GardenTask.Add(gardenTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGardenTask", new { id = gardenTask.Id }, gardenTask);
        }

        // DELETE: api/GardenTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGardenTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gardenTask = await _context.GardenTask.SingleOrDefaultAsync(m => m.Id == id);
            if (gardenTask == null)
            {
                return NotFound();
            }

            _context.GardenTask.Remove(gardenTask);
            await _context.SaveChangesAsync();

            return Ok(gardenTask);
        }

        private bool GardenTaskExists(int id)
        {
            return _context.GardenTask.Any(e => e.Id == id);
        }
    }
}