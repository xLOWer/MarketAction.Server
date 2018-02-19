using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public class User : BaseEntity
    {
        public User()
        {
            IsRemoved = false;
        }
        
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime LastEntryDate { get; set; }
        
        public Guid? PersonId { get; set; }

        [NotMapped]
        public Person Person { get; set; }
        [NotMapped]
        public ICollection<AccessLevel> AccessLevels { get; set; }
    }
}
