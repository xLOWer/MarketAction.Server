﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public class Good : BaseEntity
    {
        public Good()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Cost { get; set; }

        [NotMapped]
        public ICollection<Market> Markets { get; set; }
        [NotMapped]
        public ICollection<Action> Actions { get; set; }
        [NotMapped]
        public ICollection<Catalogue> Catalogues { get; set; }
    }
}
