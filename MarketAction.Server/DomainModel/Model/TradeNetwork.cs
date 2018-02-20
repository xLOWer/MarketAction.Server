using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class TradeNetwork : BaseEntity
    {
        public TradeNetwork()
        {}

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        
        [NotMapped]
        public ICollection<Catalogue> Catalogues { get; set; }
        [NotMapped]
        public ICollection<Market> Markets { get; set; }
    }
}