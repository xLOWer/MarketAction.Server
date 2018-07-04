using System.Collections.Generic;
using System.Linq;
using EntityFrameworkCore.DomianModel;
using EntityFrameworkCore.DomianModel.Model;
using MarketAction.Server.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MarketAction.Server.Services
{
    [Produces("application/json")]
    [Route("api/tradenetworks")]
    public class TradeNetworksService : DomainController<TradeNetwork>
    {
        public TradeNetworksService(MaDbContext context) : base(context)
        {
            TradeNetworks = context?
                .TradeNetworks?
                .Where(x => !x.IsRemoved)?
                .OrderBy(x => x.Name)
                .ToList();
        }

        [HttpGet]
        public IEnumerable<TradeNetwork> GetAll() => TradeNetworks ?? new List<TradeNetwork>();
    }
}