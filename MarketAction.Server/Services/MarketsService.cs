using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.DomianModel;
using EntityFrameworkCore.DomianModel.Model;
using MarketAction.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAction.Server.Services
{
    [Produces("application/json")]
    [Route("api/markets")]
    public class MarketsService : DomainController<Market>
    {
        public MarketsService(MaDbContext context) : base(context)
        {
            Markets = context?
                .Markets?
                .Include(x => x.TradeNetwork)?
                .Where(x => !x.IsRemoved)?
                .ToList();
        }

        [HttpGet]
        public IEnumerable<Market> GetAll() => Markets ?? new List<Market>();

        [HttpGet("findbytradenetwork/{id}")]
        public IEnumerable<Market> GetByTradeNetworktId([FromRoute] Guid? id)
            => id == null || id == Guid.Empty
                ? GetAll()
                : Markets.Where(x => x.TradeNetworkId == id);
    }
}