﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
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
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
             
        [NotMapped]
        public TradeNetwork TradeNetwork { get; set; }
        public Guid? TradeNetworkId { get; set; }
    }
}
