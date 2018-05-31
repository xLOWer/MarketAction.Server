using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class Action : BaseEntity
    {
        public Action()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
            CreateDate = DateTime.Now;
            LastEditDate = CreateDate;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateActionStart { get; set; }
        public DateTime? DateActionEnd { get; set; }

        [NotMapped]
        public TradeNetwork TradeNetwork { get; set; }
        public Guid? TradeNetworkId { get; set; }

        [NotMapped]
        public ICollection<Product> Products { get; set; }
    }
}
