using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EntityFrameworkCore.DomianModel.Model
{
    public class TradeNetwork : BaseEntity
    {
        public TradeNetwork()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
            CreateDate = DateTime.Now;
            LastEditDate = CreateDate;
            Markets = new HashSet<Market>();
            Actions = new HashSet<Action>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        
        [NotMapped] public virtual ICollection<Market> Markets { get; set; }
        [NotMapped] public virtual ICollection<Action> Actions { get; set; }
    }
}