using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IcarufyGarden.Data;
using IcarufyGarden.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace IcarufyGarden.Controllers
{

    [Authorize(Policy = "ApiUser")]
    [Produces("application/json")]
    [Route("api/GardenBeds")]
    public class GardenBedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GardenBedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GardenBeds
        [HttpGet]
        public IEnumerable<GardenBed> GetGardenBeds()
        {
            return _context.GardenBeds;
            // Dont include gardenbedTasks - this will break the json!
            //return _context.GardenBeds.Include(gb => gb.GardenBedTasks).ThenInclude(gbt => gbt.Select(gbti => gbti.GardenTask));            
        }

        // GET: api/GardenBeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGardenBed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gardenBed = await _context.GardenBeds.SingleOrDefaultAsync(m => m.Id == id);

            if (gardenBed == null)
            {
                return NotFound();
            }

            return Ok(gardenBed);
        }

        // PUT: api/GardenBeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGardenBed([FromRoute] int id, [FromBody] GardenBed gardenBed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gardenBed.Id)
            {
                return BadRequest();
            }

            _context.Entry(gardenBed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenBedExists(id))
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

        // POST: api/GardenBeds
        [HttpPost]
        public async Task<IActionResult> PostGardenBed([FromBody] GardenBed gardenBed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GardenBeds.Add(gardenBed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGardenBed", new { id = gardenBed.Id }, gardenBed);
        }

        // DELETE: api/GardenBeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGardenBed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gardenBed = await _context.GardenBeds.SingleOrDefaultAsync(m => m.Id == id);
            if (gardenBed == null)
            {
                return NotFound();
            }

            _context.GardenBeds.Remove(gardenBed);
            await _context.SaveChangesAsync();

            return Ok(gardenBed);
        }

        private bool GardenBedExists(int id)
        {
            return _context.GardenBeds.Any(e => e.Id == id);
        }
    }
}
