using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkCore.DomianModel;
using EntityFrameworkCore.DomianModel.Model;
using MarketAction.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MarketAction.Server.Services
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsService : DomainController<Product>
    {
        public ProductsService(MaDbContext context) : base(context)
        {
            Products = context?
                .Products?
                .Include(x => x.Action)?
                .ThenInclude(x => x.TradeNetwork)?
                .Where(x => !x.IsRemoved)?
                .OrderBy(x => x.Name)
                .ToList();
        }

        [HttpGet]
        public IEnumerable<Product> GetAll() => Products ?? new List<Product>();

        [HttpGet("sort/{sort}")]
        public IEnumerable<Product> GetAllSorted([FromRoute] string sort)
        {
            switch (sort)
            {
                case "n": return Products.OrderBy(x => x.Name).ToList(); 
                case "N": return Products.OrderBy(x => x.Name).Reverse().ToList();

                case "c": return Products.OrderBy(x => x.Cost).ToList(); 
                case "C": return Products.OrderBy(x => x.Cost).Reverse().ToList();

                case "w": return Products.OrderBy(x => x.Weight).ToList(); 
                case "W": return Products.OrderBy(x => x.Weight).Reverse().ToList();

                case "m": return Products.OrderBy(x => x.Manufacturer).ToList();
                case "M": return Products.OrderBy(x => x.Manufacturer).Reverse().ToList(); 

                default : return Products.OrderBy(x => x.Name).ToList();
            }
        }

        [HttpGet("findbyaction/{id}")]
        public IEnumerable<Product> GetByActionId([FromRoute] Guid? id)
            => id == null || id == Guid.Empty
                ? GetAll()
                : Products?.Where(x => x.ActionId == id);

        [HttpGet("findbytradenetwork/{id}")]
        public IEnumerable<Product> GetByTradeNetworktId([FromRoute] Guid? id)
            => id == null || id == Guid.Empty
                ? GetAll()
                : Products.Where(x => x.Action.TradeNetworkId == id);
        
        [HttpPost("findbycriteria")]
        public IEnumerable<Product> Find([FromBody] string filter) =>
            String.IsNullOrEmpty(filter)
                ? GetAll()
                : GetByCriteria(JsonConvert.DeserializeObject<List<string>>(filter));
        
        public IEnumerable<Product> GetByCriteria(List<string> criterias)
        {
            var res = Products;
            var get = res;
            foreach (var s in criterias)
            {
                var buffer = get?.Where(x => x.Name.ToLower().Contains(s.ToLower())
                                             || x.Manufacturer.ToLower().Contains(s.ToLower())
                                             || x.Cost.ToLower().Contains(s.ToLower())
                                             || x.Weight.ToLower().Contains(s.ToLower()));
                res = res?.Intersect(buffer);
            }

            return res ?? GetAll();
        }

        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid? id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await Context?.Products?
                .Include(x => x.Action)?
                .Where(x => !x.IsRemoved)?
                .SingleOrDefaultAsync(m => m.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
         
        // PUT: UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != product.Id)
                return BadRequest();

            Context.Entry(product).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(id))
                    return NotFound();
                else throw;
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
            
            Context.Products.Add(product);
            await Context.SaveChangesAsync();

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

            var product = await Context.Products.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            Context.Products.Remove(product);
            await Context.SaveChangesAsync();

            return Ok(product);
        }
        
        public bool IsExists(Guid id)
        {
            return Context.Products.Any(e => e.Id == id);
        }
        */
    }
}