using System;
using System.Collections.Generic;
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

        [NotMapped]
        public AccessLevel AccessLevel { get; set; }
        public Guid? AccessLevelId { get; set; }

        [NotMapped]
        public Stamp DateStamp { get; set; }
        public Guid? DateStampId { get; set; }
        
        [NotMapped]
        public Person Person { get; set; }
        public Guid? PersonId { get; set; }
    }
}
