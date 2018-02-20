using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class AccessLevel : BaseEntity
    {
        public AccessLevel()
        {}

        public string Name { get; set; }
        public bool ReadAll { get; set; }
        public bool WriteAll { get; set; }
        public bool ReadGoods { get; set; }
        public bool WriteGoods { get; set; }
        public bool ReadTradeNetworks { get; set; }
        public bool WriteTradeNetworks { get; set; }
        public bool ReadUsers { get; set; }
        public bool WriteUsers { get; set; }
        public bool ReadPersons { get; set; }
        public bool WritePersons { get; set; }
        public bool ReadAccessLevels { get; set; }
        public bool WriteAccessLevels { get; set; }
        public bool ReadCatalogues { get; set; }
        public bool WriteCatalogues { get; set; }
        public bool ReadStamps { get; set; }
        public bool WriteStamps { get; set; }
        
        [NotMapped]
        public ICollection<User> Users { get; set; }
    }
}
