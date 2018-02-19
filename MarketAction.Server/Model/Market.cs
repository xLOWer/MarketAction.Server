using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public class Market : BaseEntity
    {
        public Market()
        {
        }

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
