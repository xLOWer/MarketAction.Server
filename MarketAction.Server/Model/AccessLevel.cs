using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public class AccessLevel : BaseEntity
    {
        public AccessLevel()
        {
        }

        public string Login { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public Stamp DateStamp { get; set; }
        public Guid? DateStampId { get; set; }

        [NotMapped]
        public ObservableCollection<User> Users { get; set; }
    }
}
