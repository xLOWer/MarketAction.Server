using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class TradeNetwork : BaseEntity
    {
        public TradeNetwork()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
            CreateDate = DateTime.Now;
            LastEditDate = CreateDate;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        
        [NotMapped]
        public ICollection<Market> Markets { get; set; }
        [NotMapped]
        public ICollection<Action> Actions { get; set; }
    }
}