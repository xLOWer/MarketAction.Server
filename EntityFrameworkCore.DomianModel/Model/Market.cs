using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EntityFrameworkCore.DomianModel.Model;
using Newtonsoft.Json;

namespace EntityFrameworkCore.DomianModel.Model
{
    public class Market : BaseEntity
    {
        public Market()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
            CreateDate = DateTime.Now;
            LastEditDate = CreateDate;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public Guid? TradeNetworkId { get; set; }

        [NotMapped] public virtual string TradeNetworkName => TradeNetwork?.Name ?? "undefined";
        [NotMapped] public virtual TradeNetwork TradeNetwork { get; set; }
    }
}
