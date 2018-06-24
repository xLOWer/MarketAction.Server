using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.DomianModel;
using MarketAction.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Action = EntityFrameworkCore.DomianModel.Model.Action;

namespace MarketAction.Server.Services
{
    [Produces("application/json")]
    [Route("api/actions")]
    public class ActionsService : DomainController<Action>
    {
        public ActionsService(MaDbContext context) : base(context)
        {
            Actions = context?
                .Actions?
                .Include(x=>x.TradeNetwork)?
                .Where(x => !x.IsRemoved)?
                .ToList();
        }

        [HttpGet]
        public IEnumerable<Action> GetAll() => Actions ?? new List<Action>();

        [HttpGet("findbytradenetwork/{id}")]
        public IEnumerable<Action> GetByTradeNetworktId([FromRoute] Guid? id)
            => id == null || id == Guid.Empty
                ? GetAll()
                : Actions.Where(x => x.TradeNetworkId == id);
    }
}