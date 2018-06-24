using System.Collections.Generic;
using EntityFrameworkCore.DomianModel;
using EntityFrameworkCore.DomianModel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//insert into Goods (Id,Cost,Description,Name,Weight,CreateDate,LastEditDate,IsRemoved) values (NEWID(),200,'some description2','SOME NAME2',2668,GETDATE(),GETDATE(),0);

namespace MarketAction.Server.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class DomainController<T> : Controller
    {
        public readonly MaDbContext Context;

        public IEnumerable<T> Actions { get; set; }
        public IEnumerable<T> Markets { get; set; }
        public IEnumerable<T> Products { get; set; }
        public IEnumerable<T> TradeNetworks { get; set; }

        public DomainController(MaDbContext context)
        {
            Context = context;
        }
    }
}