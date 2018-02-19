using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public class Stamp : BaseEntity
    {
        public Stamp()
        {
            CreateDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        public DateTime CreateDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        [NotMapped]
        public User UserCreator { get; set; }
        [NotMapped]
        public User UserLastEditor { get; set; }
        [NotMapped]
        public User UserRemover { get; set; }
    }
}
