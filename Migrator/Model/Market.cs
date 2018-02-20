using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class Market : BaseEntity
    {
        public Market()
        {}

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public Guid? TradeNetworkId { get; set; }
        
        [NotMapped]
        public TradeNetwork TradeNetwork { get; set; }
        [NotMapped]
        public ICollection<Good> Goods { get; set; }
    }
}
