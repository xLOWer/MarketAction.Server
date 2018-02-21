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
    [Route("api/Goods")]
    public class GoodsController : Controller
    {
        private readonly MaDbContext _context;

        public GoodsController(MaDbContext context)
        {
            _context = context;
        }

        // GET: api/Goods
        [HttpGet]
        public IEnumerable<Good> GetGoods()
        {
            return _context.Goods;
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGood([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var good = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);

            if (good == null)
            {
                return NotFound();
            }

            return Ok(good);
        }

        // PUT: api/Goods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGood([FromRoute] Guid id, [FromBody] Good good)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != good.Id)
            {
                return BadRequest();
            }

            _context.Entry(good).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(id))
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

        // POST: api/Goods
        [HttpPost]
        public async Task<IActionResult> PostGood([FromBody] Good good)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Goods.Add(good);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGood", new { id = good.Id }, good);
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGood([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var good = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();

            return Ok(good);
        }

        private bool GoodExists(Guid id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}