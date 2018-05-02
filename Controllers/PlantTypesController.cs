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
    [Route("api/PlantTypes")]
    public class PlantTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PlantTypes
        [HttpGet]
        public IEnumerable<PlantType> GetPlantTypes()
        {
            return _context.PlantTypes;
        }

        // GET: api/PlantTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlantType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantType = await _context.PlantTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (plantType == null)
            {
                return NotFound();
            }

            return Ok(plantType);
        }

        // PUT: api/PlantTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantType([FromRoute] int id, [FromBody] PlantType plantType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plantType.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantTypeExists(id))
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

        // POST: api/PlantTypes
        [HttpPost]
        public async Task<IActionResult> PostPlantType([FromBody] PlantType plantType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlantTypes.Add(plantType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantType", new { id = plantType.Id }, plantType);
        }

        // DELETE: api/PlantTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantType = await _context.PlantTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (plantType == null)
            {
                return NotFound();
            }

            _context.PlantTypes.Remove(plantType);
            await _context.SaveChangesAsync();

            return Ok(plantType);
        }

        private bool PlantTypeExists(int id)
        {
            return _context.PlantTypes.Any(e => e.Id == id);
        }
    }
}
