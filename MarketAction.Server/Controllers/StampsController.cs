using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketAction.Server.Model;
using MarketAction.Server.Models;

namespace MarketAction.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Stamps")]
    public class StampsController : Controller
    {
        private readonly MaDbContext _context;

        public StampsController(MaDbContext context)
        {
            _context = context;
        }

        // GET list: api/Stamps
        [HttpGet]
        public IEnumerable<Stamp> GetStamps()
        {
            return _context.Stamps;
        }

        // GET by id: api/Stamps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStamp([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stamp = await _context.Stamps.SingleOrDefaultAsync(m => m.Id == id);

            if (stamp == null)
            {
                return NotFound();
            }

            return Ok(stamp);
        }

        // PUT update by id: api/Stamps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStamp([FromRoute] Guid id, [FromBody] Stamp stamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stamp.Id)
            {
                return BadRequest();
            }

            _context.Entry(stamp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StampExists(id))
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

        // POST add new: api/Stamps
        [HttpPost]
        public async Task<IActionResult> PostStamp([FromBody] Stamp stamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stamps.Add(stamp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStamp", new { id = stamp.Id }, stamp);
        }

        // DELETE delete by id: api/Stamps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStamp([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stamp = await _context.Stamps.SingleOrDefaultAsync(m => m.Id == id);
            if (stamp == null)
            {
                return NotFound();
            }

            _context.Stamps.Remove(stamp);
            await _context.SaveChangesAsync();

            return Ok(stamp);
        }

        private bool StampExists(Guid id)
        {
            return _context.Stamps.Any(e => e.Id == id);
        }
    }
}