using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
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

        [NotMapped]
        public Action Action { get; set; }
        public Guid? ActionId { get; set; }
    }
}
