using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketAction.Server.EntityFrameworkCore.DomianModel;

namespace MarketAction.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Actions")]
    public class ActionsService : DomainController
    {
        public ActionsService(MaDbContext context) : base(context)
        {}
        
        //GET
        [HttpGet]
        public IEnumerable<Model.Action> Get() => _context.Actions;

        //GET by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var action = await _context.Actions.SingleOrDefaultAsync(m => m.Id == id);

            if (action == null)
            {
                return NotFound();
            }

            return Ok(action);
        }

        // PUT: UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Model.Action action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != action.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(action).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(id))
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

        // POST: INSERT
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Model.Action action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Actions.Add(action);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAction", new { id = action.Id }, action);
        }

        // DELETE DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var action = await _context.Actions.SingleOrDefaultAsync(m => m.Id == id);
            if (action == null)
            {
                return NotFound();
            }

            _context.Actions.Remove(action);
            await _context.SaveChangesAsync();

            return Ok(action);
        }

        public bool IsExists(Guid id)
        {
            return _context.Actions.Any(e => e.Id == id);
        }
    }
}