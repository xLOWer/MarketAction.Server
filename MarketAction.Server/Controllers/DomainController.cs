using Microsoft.AspNetCore.Mvc;
using MarketAction.Server.EntityFrameworkCore.DomianModel;

//insert into Goods (Id,Cost,Description,Name,Weight,CreateDate,LastEditDate,IsRemoved) values (NEWID(),200,'some description2','SOME NAME2',2668,GETDATE(),GETDATE(),0);

namespace MarketAction.Server.Controllers
{
    public class DomainController : Controller
    {
        public readonly MaDbContext _context;

        public DomainController(MaDbContext context)
        {
            _context = context;
        }

    }
}