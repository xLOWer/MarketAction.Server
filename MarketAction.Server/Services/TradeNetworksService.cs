using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.DomianModel;
using EntityFrameworkCore.DomianModel.Model;
using MarketAction.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
                .ToList();
        }

        [HttpGet]
        public IEnumerable<TradeNetwork> GetAll() => TradeNetworks ?? new List<TradeNetwork>();
    }
}