using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public class TradeNetwork : BaseEntity
    {
        public TradeNetwork()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        
        [NotMapped]
        public Stamp DateStamp { get; set; }
        public Guid? DateStampId { get; set; }
        
        [NotMapped]
        public ObservableCollection<Market> Markets { get; set; }

    }
}
