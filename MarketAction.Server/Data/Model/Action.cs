using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class Action : BaseEntity
    {
        public Action()
        {}

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Cost { get; set; }
        public string SalePercent { get; set; }
        public string NewCost { get; set; }
        public DateTime? DateActionStart { get; set; }
        public DateTime? DateActionEnd { get; set; }
        
        [NotMapped]
        public ICollection<Good> Goods { get; set; }
    }
}
