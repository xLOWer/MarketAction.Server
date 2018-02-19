using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public class Catalogue : BaseEntity
    {
        public Catalogue()
        {
        }

        public string Name { get; set; }
        
        public Guid? TradeNetworkId { get; set; }
        
        [NotMapped]
        public TradeNetwork TradeNetwork { get; set; }        
        [NotMapped]
        public ICollection<Good> Goods { get; set; }
    }
}
