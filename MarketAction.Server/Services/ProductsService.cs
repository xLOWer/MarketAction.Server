using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketAction.Server.EntityFrameworkCore.DomianModel;
using MarketAction.Server.Model;
using Newtonsoft.Json;

namespace MarketAction.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsService : DomainController
    {
        public ProductsService(MaDbContext context) : base(context)
        { }

        //GET
        [HttpGet]
        public IEnumerable<Product> Get() => _context.Products;

        //GET
        [HttpGet("Find")]
        public IEnumerable<Product> GetFiltered(string filter)
        {
            if (filter == null) return Get();
            List<string> m = JsonConvert.DeserializeObject<List<string>>(filter);
            return Get()
                .Where(prod =>
                    prod.Manufacturer.Any(x => m)) ||
                    prod.Name.Any(x => m.Contains(x.ToString())) ||
                    prod.Weight.Any(x => m.Contains(x.ToString())) ||
                    prod.Cost.Any(x => m.Contains(x.ToString())
                )
            );
        }

        [HttpPost("Find")]
        public IEnumerable<Product> Find([FromBody] string filter)
        {
            if (String.IsNullOrEmpty(filter)) return Get();
            return GetFiltered(filter);
        }

        //GET by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

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
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        public bool IsExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}