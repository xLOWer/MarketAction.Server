using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EntityFrameworkCore.DomianModel.Model;
using Newtonsoft.Json;

namespace EntityFrameworkCore.DomianModel.Model
{
    public class Action : BaseEntity
    {
        public Action()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
            CreateDate = DateTime.Now;
            LastEditDate = CreateDate;
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateActionStart { get; set; }
        public DateTime? DateActionEnd { get; set; }
        public Guid? TradeNetworkId { get; set; }
        
        [NotMapped] public virtual string TradeNetworkName => TradeNetwork?.Name ?? "undefined";
        [NotMapped] public virtual TradeNetwork TradeNetwork { get; set; }
        [NotMapped] public virtual ICollection<Product> Products { get; set; }
    }
}
