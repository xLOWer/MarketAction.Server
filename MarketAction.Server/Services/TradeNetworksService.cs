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
    [Route("api/TradeNetworks")]
    public class TradeNetworksService : DomainController
    {
        public TradeNetworksService(MaDbContext context) : base(context)
        {}
        
        //GET
        [HttpGet]
        public IEnumerable<TradeNetwork> Get() => _context.TradeNetworks;

        //private 
        
        //GET by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tradeNetwork = await _context.TradeNetworks.SingleOrDefaultAsync(m => m.Id == id);

            if (tradeNetwork == null)
            {
                return NotFound();
            }

            return Ok(tradeNetwork);
        }

        // PUT: UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] TradeNetwork tradeNetwork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tradeNetwork.Id)
            {
                return BadRequest();
            }

            _context.Entry(tradeNetwork).State = EntityState.Modified;

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
        public async Task<IActionResult> Post([FromBody] TradeNetwork tradeNetwork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.TradeNetworks.Add(tradeNetwork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = tradeNetwork.Id }, tradeNetwork);
        }

        // DELETE DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tradeNetwork = await _context.TradeNetworks.SingleOrDefaultAsync(m => m.Id == id);
            if (tradeNetwork == null)
            {
                return NotFound();
            }

            _context.TradeNetworks.Remove(tradeNetwork);
            await _context.SaveChangesAsync();

            return Ok(tradeNetwork);
        }

        public bool IsExists(Guid id)
        {
            return _context.TradeNetworks.Any(e => e.Id == id);
        }
    }
}