using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class Good : BaseEntity
    {
        public Good()
        {}

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Weight { get; set; }
        public decimal Cost { get; set; }
        public decimal NewStr { get; set; }

        [NotMapped]
        public ICollection<Market> Markets { get; set; }
        [NotMapped]
        public ICollection<Action> Actions { get; set; }
        [NotMapped]
        public ICollection<Catalogue> Catalogues { get; set; }
    }
}
