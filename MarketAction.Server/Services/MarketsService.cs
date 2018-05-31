using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketAction.Server.EntityFrameworkCore.DomianModel;
using MarketAction.Server.Model;

namespace MarketAction.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Markets")]
    public class MarketsService : DomainController
    {
        public MarketsService(MaDbContext context) : base(context)
        {}
        
        //GET
        [HttpGet]
        public IEnumerable<Market> Get() => _context.Markets;

        //private 
        
        //GET by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var market = await _context.Markets.SingleOrDefaultAsync(m => m.Id == id);

            if (market == null)
            {
                return NotFound();
            }

            return Ok(market);
        }

        // PUT: UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Market market)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != market.Id)
            {
                return BadRequest();
            }

            _context.Entry(market).State = EntityState.Modified;

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
        public async Task<IActionResult> Post([FromBody] Market market)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Markets.Add(market);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarket", new { id = market.Id }, market);
        }

        // DELETE DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var market = await _context.Markets.SingleOrDefaultAsync(m => m.Id == id);
            if (market == null)
            {
                return NotFound();
            }

            _context.Markets.Remove(market);
            await _context.SaveChangesAsync();

            return Ok(market);
        }

        public bool IsExists(Guid id)
        {
            return _context.Markets.Any(e => e.Id == id);
        }
    }
}