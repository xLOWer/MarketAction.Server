using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketAction.Server.EntityFrameworkCore.DomianModel;
using MarketAction.Server.Model;

namespace MarketAction.Server.Controllers
{//insert into Goods (Id,Cost,Description,Name,Weight,CreateDate,LastEditDate,IsRemoved) values (NEWID(),200,'some description2','SOME NAME2',2668,GETDATE(),GETDATE(),0);
    [Produces("application/json")]
    [Route("api/Goods")]
    public class GoodsService : DomainController
    {
        private Guid techGuid = Guid.Parse("ffff0000-0000-0000-0000-0000ffff0000");
        public GoodsService(MaDbContext context) : base(context)
        {}
        
        [HttpGet]
        public IEnumerable<Good> Get() => _context.Goods;
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if(id == techGuid)
            {
                _context.Goods.Add(new Good() {
                    Id = Guid.NewGuid(),
                    Cost = new Random(24363).Next(1,9999),
                    Name ="somename"+ new Random(24363).Next(1, 9999).ToString() + new Random(24363).Next(1, 9999).ToString() + new Random(24363).Next(1, 9999).ToString(),
                    Weight = new Random(24363).Next(1, 9999)
                });
                await _context.SaveChangesAsync();
            }
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

        // PUT: api/Goods/guid
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Good good)
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

        // POST: api/Goods
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Good good)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Goods.Add(good);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGood", new { id = good.Id }, good);
        }

        // DELETE: api/Goods/guid
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
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

        public bool IsExists(Guid id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}