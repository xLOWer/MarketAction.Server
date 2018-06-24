using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EntityFrameworkCore.DomianModel.Model
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
            CreateDate = DateTime.Now;
            LastEditDate = CreateDate;
        }
        
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Weight { get; set; }
        public string Cost { get; set; }
        public Guid? ActionId { get; set; }

        [NotMapped] public virtual string ActionName => Action?.Name ?? "undefined";
        [NotMapped] public virtual string TradeNetworkName => Action?.TradeNetworkName ?? "undefined";
        [NotMapped] public virtual Action Action { get; set; }
    }
}